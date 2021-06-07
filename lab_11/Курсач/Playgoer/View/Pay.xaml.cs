using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для Pay.xaml
    /// </summary>
    public partial class Pay : Window
    {
        private string usrLgn;

        private string strFrom = "maria03052000@mail.ru";
        private string strFromCut = "";
        private string strMailSubject = "Входной билет";
        private string strMailBody = "";
        private int mailIndex;
        private bool mailFlag = true;
        // mail password
        #region
        private string pass = "vfkmdbyf577";
        #endregion

        private Guid strThId;
        private bool equalMonthes = false;
        private bool paidFlag = false;

        private int rowStart = 0;
        private int seatStart = 0;
        private int ticketSum = 0;
        
        private Seat seat = new Seat();
        private Performance selPerf = new Performance();

        private List<Button> btnsLi = new List<Button>();
        private List<Seat> seatsList = new List<Seat>();

        public Pay(string userLogin, List<Button> btnsList, Performance selectedPerf)
        {
            InitializeComponent();

            usrLgn = userLogin;
            btnsLi = btnsList;
            selPerf = selectedPerf;
            
            // расшифровка названия кнопок, определение сектора, ряда и места
            foreach (var btn in btnsLi)
            {
                using (Model1 db = new Model1())
                {
                    if ((btn.Name).Contains("P"))
                    {
                        rowStart = (btn.Name).IndexOf("P");
                        seatStart = (btn.Name).IndexOf("s");

                        string row = (btn.Name).Substring(rowStart + 1, seatStart - rowStart - 1);
                        string seatNum = (btn.Name).Substring(seatStart + 1);

                        seat = db.Seats.Where(s => s.Sector == "Партер" && s.Row.ToString() == row && s.SeatNum.ToString() == seatNum).FirstOrDefault();
                        seatsList.Add(seat);
                        ticketSum += (int)seat.Price;
                    }
                    else if ((btn.Name).Contains("B"))
                    {
                        rowStart = (btn.Name).IndexOf("B");
                        seatStart = (btn.Name).IndexOf("s");

                        string row = (btn.Name).Substring(rowStart + 1, seatStart - rowStart - 1);
                        string seatNum = (btn.Name).Substring(seatStart + 1);

                        seat = db.Seats.Where(s => s.Sector == "Балкон" && s.Row.ToString() == row && s.SeatNum.ToString() == seatNum).FirstOrDefault();
                        seatsList.Add(seat);
                        ticketSum += (int)seat.Price;
                    }
                    else 
                    {
                        MessageBox.Show("error button");
                    }
                }
            }            

            sumBlock.Text = ticketSum.ToString();            
        }

        // Оплатить
        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            string errorStr = "";
            int num;
            long numLong;
            int yearNow = (DateTime.Now).Year;
            int monthNow = (DateTime.Now).Month;

            if (cardNum.Text == "" && month.Text == "" && year.Text == "" && name.Text == "" && surname.Text == "" && cvv.Text == "")
            {
                errorStr += "Заполните все поля. ";
            }

            if (!long.TryParse(cardNum.Text, out numLong))
            {
                errorStr += "Введите номер карты в числовом формате. ";
            }

            if (!int.TryParse(month.Text, out num))
            {
                errorStr += "Введите месяц в числовом формате. ";
            }
            else
            {
                if (num <= monthNow)
                {
                    equalMonthes = true;
                }
                if (num < 1 || num > 12)
                {
                    errorStr += "Проверьте корректность введённого месяца (от 1 до 12). ";
                }
            }

            if (!int.TryParse(year.Text, out num))
            {
                errorStr += "Введите год в числовом формате. ";
            }
            else
            {
                if (num <= yearNow-2000 && equalMonthes)
                {
                    errorStr += "Невозможно совершить оплату. Срок действия карты истёк. ";                    
                }

                equalMonthes = false;
            }

            if (!int.TryParse(cvv.Text, out num))
            {
                errorStr += "Введите CVV-код в числовом формате. ";
            }
            else
            {
                if (num < 100 || num > 999)
                {
                    errorStr += "Проверьте корректность введённого CVV-кода. ";
                }
            }

            if (errorStr != "")
                MessageBox.Show(errorStr);            
            else
            {
                int countPaidTicks = 0;
                
                foreach (var st in seatsList)
                {                        
                    using (Model1 db = new Model1())
                    {
                        if (db.Tickets.Where(tck => tck.SeatId == st.Id && tck.PerformanceId == selPerf.Id).FirstOrDefault() == null)
                        {
                            Ticket tick = new Ticket();
                            tick.Id = Guid.NewGuid();
                            tick.PerformanceId = selPerf.Id;
                            tick.SeatId = st.Id;
                            tick.UserId = (db.Users.Where(us => us.Login == usrLgn).FirstOrDefault()).Id;

                            db.Tickets.Add(tick);
                            db.SaveChanges();

                            countPaidTicks++;

                            strThId = (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).TheaterId;

                            // название театра
                            strMailBody = (db.Theaters.FirstOrDefault(th => th.Id == strThId)).TName + "\n";
                            // название спектакля
                            strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).PName + "\n\n";
                            // дата
                            strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).Date_time.Date.ToString("d") + " ";
                            // время
                            strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).Date_time.TimeOfDay.ToString() + "\n\n";
                            // сектор
                            strMailBody += (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Sector + "\n";
                            // ряд
                            strMailBody += "Ряд: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Row + "\n";
                            // место
                            strMailBody += "Место: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).SeatNum + "\n\n";
                            // цена билета
                            strMailBody += "Цена билета: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Price + "\n\n\n";
                            // подпись
                            strMailBody += "Отправлено из Playgoer";

                            // e-mail
                            try
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
                                message.To.Add(new MailAddress((db.Users.Where(us => us.Login == usrLgn).FirstOrDefault()).Email));
                                // тема письма
                                message.Subject = strMailSubject;
                                // текст письма
                                message.Body = strMailBody;
                                // будет использоваться протокол SSL при отправке
                                smtp1.EnableSsl = true;
                                // отправка
                                smtp1.Send(message);

                            }
                            catch
                            {
                                mailFlag = false;
                                MessageBox.Show("Уведомления не были отправлены. Проверьте подключение к интернету"); ;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Это место занято");
                        }

                        //this.Close();
                    }
                }

                if (mailFlag)
                {
                    MessageBox.Show("Уведомления отправлены");
                }

                if (countPaidTicks == seatsList.Count())
                {
                    paidFlag = true;
                    MessageBox.Show("Оплачено");
                }
                else
                {
                    MessageBox.Show("Возникли проблемы с оплатой. Пожалуйста, повторите попытку.");
                }

                this.Close();                
            }   
        }

        // При закрытии окна
        private void PayWindow_Closing(object sender, CancelEventArgs e)
        {
            // возвращение кнопкам прежнего вида
            foreach (var btn in btnsLi)
            {
                btn.ClearValue(Button.BackgroundProperty);
            }

            // очистить список выбранных кнопок
            btnsLi.Clear();

            if (!paidFlag)
            {
                MessageBox.Show("Оплата отменена");
            }
            
        }
    }
}
