using System;
using System.Linq;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для AddPerformance.xaml
    /// </summary>
    public partial class AddPerformance : Window
    {
        private string strFrom = "maria03052000@mail.ru";
        private string strFromCut = "";
        private string strMailSubject = "Добавлен новый спектакль";
        private string strMailBody = "Любимый зритель!\nРады сообщить вам, что в нашей афише появился новый спектакль! Не пропустите! Заходите и выбирайте лучшие места.\n\n\nАфиша Playgoer";
        private int mailIndex;
        // mail password
        #region
        private string pass = "vfkmdbyf577";
        #endregion

        public AddPerformance()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((pNameBox.Text != "") && (genreBox.Text != "") && (ageBox.Text != "") && (durBox.Text != "") && (dateBox.Text != "") && (timeBox.Text != "") && (tNameBox.Text != ""))
            {
                int dd, mm, yyyy, hh, mon;
                int age;
                int duration;

                bool success = int.TryParse(ageBox.Text, out age);
                bool success2 = int.TryParse(durBox.Text, out duration);

                string strDate = dateBox.Text;   // dd.mm.yyyy [0123456789]
                string strTime = timeBox.Text;   // hh:mm [01234]

                if (strDate.Length == 10)
                {
                    if (strTime.Length == 5)
                    {
                        DateTime dateTime = new DateTime();

                        // проверка на числовые значения в полях дата и время
                        if (int.TryParse(strDate.Substring(0, 2), out dd) && int.TryParse(strDate.Substring(6, 4), out yyyy) && int.TryParse(strDate.Substring(3, 2), out mon)
                                                && int.TryParse(strTime.Substring(0, 2), out hh) && int.TryParse(strTime.Substring(3, 2), out mm))
                        {
                            // если числа даты и времени не совпадают со стандартными
                            try
                            {
                                dateTime = new DateTime(yyyy, mon, dd, hh, mm, 0);

                                if (success && success2)
                                {
                                    using (Model1 db = new Model1())
                                    {
                                        var thr = db.Theaters.FirstOrDefault(th => th.TName == tNameBox.Text);

                                        if (thr != null)
                                        {
                                            // Название спектакля, место проведения и дата-время не должны совпадать одновременно
                                            // можно встретить совпадение двух из 3-х характеристик спектакля
                                            Performance prfs = db.Performances.Where(a => a.PName == pNameBox.Text && a.TheaterId == thr.Id
                                                                                            && a.Date_time == dateTime).FirstOrDefault();

                                            if (prfs == null)
                                            {
                                                Performance prf = new Performance();
                                                prf.Id = Guid.NewGuid();
                                                prf.PName = pNameBox.Text;
                                                prf.Genre = genreBox.Text;
                                                prf.Age = age;
                                                prf.Duration = duration;
                                                prf.Date_time = dateTime;
                                                prf.TheaterId = thr.Id;

                                                db.Performances.Add(prf);
                                                db.SaveChanges();

                                                // e-mail
                                                try
                                                {
                                                    SendMailAsync();
                                                }
                                                catch (Exception)
                                                {
                                                    MessageBox.Show("error SendMailAsync()");
                                                }
                                                
                                                
                                                //try
                                                //{
                                                //    foreach (User usr in db.Users)
                                                //    {
                                                //        mailIndex = strFrom.IndexOf("@");
                                                //        strFromCut = strFrom.Substring(0, mailIndex);

                                                //        // адрес smtp-сервера и порт, с которого будем отправлять письмо
                                                //        SmtpClient smtp1 = new SmtpClient("smtp.mail.ru", 25);
                                                //        // аутентификационные данные отправителя: логин и пароль
                                                //        smtp1.Credentials = new NetworkCredential(strFromCut, pass);
                                                //        // создаем объект сообщения
                                                //        MailMessage message = new MailMessage();
                                                //        // отправитель - устанавливаем адрес и отображаемое в письме имя
                                                //        message.From = new MailAddress(strFrom, "Admin");
                                                //        // получатель
                                                //        message.To.Add(new MailAddress(usr.Email));
                                                //        // тема письма
                                                //        message.Subject = strMailSubject;
                                                //        // текст письма
                                                //        message.Body = strMailBody;
                                                //        // будет использоваться протокол SSL при отправке
                                                //        smtp1.EnableSsl = true;
                                                //        // отправка
                                                //        smtp1.Send(message);
                                                //    }

                                                //    MessageBox.Show("Уведомления отправлены");
                                                //}
                                                //catch (Exception)
                                                //{
                                                //    MessageBox.Show("Уведомления не были отправлены. Проверьте подключение к интернету"); ;
                                                //}

                                                MessageBox.Show("Спектакль успешно добавлен");
                                                pNameBox.Text = "";
                                                genreBox.Text = "";
                                                ageBox.Text = "";
                                                durBox.Text = "";
                                                dateBox.Text = "";
                                                timeBox.Text = "";
                                                tNameBox.Text = "";
                                                //this.Close();
                                            }
                                            else
                                                MessageBox.Show("Этот спектакль уже есть");
                                        }
                                        else
                                            MessageBox.Show("Такого театра нет в базе. Проверьте название театра");
                                    }
                                }
                                else
                                    MessageBox.Show("Ограничение по возрасту и продолжительность должны быть указаны в числовом формате");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Таких даты или времени не существует");
                            }   
                        }
                        else
                            MessageBox.Show("Проверьте дату и время. Они должны быть в числовом формате");                        
                    }
                    else
                        MessageBox.Show("Проверьте форму записи времени");
                }
                else
                    MessageBox.Show("Проверьте форму записи даты. Ставьте 0 перед каждым однозначным числом, например не 1.7.2020, а 01.07.2020");
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private void SendMail()
        {
            using (Model1 db = new Model1())
            {
                // e-mail
                try
                {
                    foreach (User usr in db.Users)
                    {
                        mailIndex = strFrom.IndexOf("@");
                        strFromCut = strFrom.Substring(0, mailIndex);

                        // адрес smtp-сервера и порт, с которого будем отправлять письмо
                        SmtpClient smtp1 = new SmtpClient("smtp.mail.ru", 25);
                        // аутентификационные данные отправителя: логин и пароль
                        smtp1.Credentials = new NetworkCredential(strFromCut, pass);
                        // создаем объект сообщения
                        MailMessage message = new MailMessage();
                        // отправитель - устанавливаем адрес и отображаемое в письме имя
                        message.From = new MailAddress(strFrom, "Admin");
                        // получатель
                        message.To.Add(new MailAddress(usr.Email));
                        // тема письма
                        message.Subject = strMailSubject;
                        // текст письма
                        message.Body = strMailBody;
                        // будет использоваться протокол SSL при отправке
                        smtp1.EnableSsl = true;
                        // отправка
                        smtp1.Send(message);
                    }

                    //MessageBox.Show("Уведомления отправлены");
                }
                catch (Exception)
                {
                    MessageBox.Show("Уведомления не были отправлены. Проверьте подключение к интернету"); ;
                }
            }
        }

        private async void SendMailAsync()
        {
            MessageBox.Show("Начало рассылки"); // выполняется синхронно
            await Task.Run(() => SendMail());                // выполняется асинхронно
            MessageBox.Show("Уведомления отправлены");
        }
    }
}
