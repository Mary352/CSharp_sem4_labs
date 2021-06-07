using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net;
using System.Net.Mail;
using Playgoer.Model.Repository_UoW;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для PayorReserve.xaml
    /// </summary>
    public partial class PayorReserve : Window
    {
        private string usrLgn;

        private string strFrom = "maria03052000@mail.ru";
        private string strFromCut = "";
        private string strMailSubject = "";
        private string strMailBody = "";
        private int mailIndex;
        private bool mailFlag = true;
        // mail password
        #region
        private string pass = "vfkmdbyf577";
        #endregion

        private Guid strThId;

        private int rowStart = 0;
        private int seatStart = 0;
        
        //private ObservableCollection<Seat> seats = new ObservableCollection<Seat>();
        private List<Button> btnsList = new List<Button>();
        private List<Seat> seatsList = new List<Seat>();
                
        private Seat seat = new Seat();
        private Performance selPerf = new Performance();

        public PayorReserve(string userLogin, Performance selectedPerf, bool? payFlag)
        {
            InitializeComponent();

            ObservableCollection<Seat> seats = new ObservableCollection<Seat>();
            string msgStr = "Осталось билетов: ";

            usrLgn = userLogin;
            selPerf = selectedPerf;

            prfBlock.Text = selectedPerf.PName;
            dateBlock.Text = selectedPerf.Date_time.Date.ToString("d");
            timeBlock.Text = selectedPerf.Date_time.TimeOfDay.ToString();

            using (UnitOfWork uow = new UnitOfWork())
            {
                Theater thr = uow.Theaters.GetConcreteObjectById(selectedPerf.TheaterId);
                thtrBlock.Text = thr.TName;
            }

            Model1 db = new Model1();
            //Theater thr = db.Theaters.FirstOrDefault(th => th.Id == selectedPerf.TheaterId);           
            //thtrBlock.Text = thr.TName;

            List<Seat> seatsList = new List<Seat>();

            // Запрос на вывод значений мест, которых нет в таблице билетов
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@iiddPrf", selPerf.Id);

            // подзапрос выбирает Id занятых мест для выбранного спектакля 
            // далее из таблицы со сведениями обо всех местах выбираются только те, которые не были возвращены в подзапросе
            seatsList.AddRange(db.Database.SqlQuery<Seat>("select * from Seats where Id not in(select SeatId from Tickets where PerformanceId = @iiddPrf) order by Sector desc, [Row], [SeatNum]", param));

            foreach (var item in seatsList)
            {
                seats.Add(item);
            }

            // оставшееся количество мест
            msgStr += seats.Count().ToString() + " из 184";
            MessageBox.Show(msgStr);

            seatsGrid.ItemsSource = seats;
        }

        //private void updateSeatsList()
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        // Запрос на вывод значений мест, которых нет в таблице билетов
        //        System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@iiddPrf", selPerf.Id);

        //        // подзапрос выбирает Id занятых мест для выбранного спектакля 
        //        // далее из таблицы со сведениями обо всех местах выбираются только те, которые не были возвращены в подзапросе
        //        seatsList.AddRange(db.Database.SqlQuery<Seat>("select * from Seats where Id not in(select SeatId from Tickets where PerformanceId = @iiddPrf) order by Sector desc, [Row], [SeatNum]", param));

        //        foreach (var item in seatsList)
        //        {
        //            seats.Add(item);
        //        }

        //        seatsGrid.ItemsSource = seats;
        //    }
        //    seatsList.Clear();
        //}

        // Бронировать
        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            if (btnsList.Count() > 0)
            {
                foreach (var btn in btnsList)
                {
                    btn.ClearValue(Button.BackgroundProperty);
                    
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
                        }
                        else if ((btn.Name).Contains("B"))
                        {
                            rowStart = (btn.Name).IndexOf("B");
                            seatStart = (btn.Name).IndexOf("s");

                            string row = (btn.Name).Substring(rowStart + 1, seatStart - rowStart - 1);
                            string seatNum = (btn.Name).Substring(seatStart + 1);

                            seat = db.Seats.Where(s => s.Sector == "Балкон" && s.Row.ToString() == row && s.SeatNum.ToString() == seatNum).FirstOrDefault();
                            seatsList.Add(seat);
                        }
                        else
                        {
                            MessageBox.Show("error btnList");
                        }
                    }
                    
                }

                int countTicksinDb = 0;

                // проверка на присутствие в бд билетов с выбранными сейчас местами
                foreach (var st in seatsList)
                {
                    using (Model1 db = new Model1())
                    {
                        if (db.Tickets.Where(tck => tck.SeatId == st.Id && tck.PerformanceId == selPerf.Id).FirstOrDefault() != null)
                        {
                            // количество билетов совпадающих с выбранными сейчас местами
                            countTicksinDb++;
                        }
                        //this.Close();
                    }
                }

                int countReservedSeats = 0;

                // если в бд билетов не нашлось совпадений с выбранными сейчас местами, то можно оплачивать
                if (countTicksinDb == 0)
                {
                    foreach (var st in seatsList)
                    {
                        using (Model1 db = new Model1())
                        {
                            //Ticket ticks = db.Tickets.Where(tick => tick. == thNameBox.Text).FirstOrDefault();

                            if (db.Tickets.Where(tck => tck.SeatId == st.Id && tck.PerformanceId == selPerf.Id).FirstOrDefault() == null)
                            {
                                Ticket tick = new Ticket();
                                tick.Id = Guid.NewGuid();
                                tick.PerformanceId = selPerf.Id;
                                tick.SeatId = st.Id;
                                tick.UserId = (db.Users.Where(us => us.Login == usrLgn).FirstOrDefault()).Id;

                                db.Tickets.Add(tick);
                                db.SaveChanges();
                                countReservedSeats++;
                                MessageBox.Show("Билет успешно добавлен");

                                //if (usrLgn.ToLower().Contains("admin") || usrLgn.ToLower().Contains("админ"))
                                //{
                                //    strMailSubject = "Пригласительный билет";

                                //    using(UnitOfWork uow = new UnitOfWork())
                                //    {
                                //        strThId = (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).TheaterId;

                                //    // название театра
                                //    strMailBody = (db.Theaters.FirstOrDefault(th => th.Id == strThId)).TName + "\n";
                                //    // название спектакля
                                //    strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).PName + "\n\n";
                                //    // дата
                                //    strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).Date_time.Date.ToString("d") + " ";
                                //    // время
                                //    strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).Date_time.TimeOfDay.ToString() + "\n\n";
                                //    // сектор
                                //    strMailBody += (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Sector + "\n";
                                //    // ряд
                                //    strMailBody += "Ряд: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Row + "\n";
                                //    // место
                                //    strMailBody += "Место: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).SeatNum + "\n\n";
                                //    // цена билета
                                //    strMailBody += "Цена билета: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Price + "\n\n\n";
                                //    // подпись
                                //    strMailBody += "Отправлено из Playgoer";
                                //    }
                                //}
                                //else
                                //{
                                //    strMailSubject = "Бронирование билета";

                                //    strThId = (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).TheaterId;

                                //    strMailBody = "Любимый зритель! Недавно вы забронировали следующий билет в приложении Playgoer: " + "\n\n";
                                //    // название театра
                                //    strMailBody += (db.Theaters.FirstOrDefault(th => th.Id == strThId)).TName + "\n";
                                //    // название спектакля
                                //    strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).PName + "\n\n";
                                //    // дата
                                //    strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).Date_time.Date.ToString("d") + " ";
                                //    // время
                                //    strMailBody += (db.Performances.Where(prf => prf.Id == selPerf.Id).FirstOrDefault()).Date_time.TimeOfDay.ToString() + "\n\n";
                                //    // сектор
                                //    strMailBody += (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Sector + "\n";
                                //    // ряд
                                //    strMailBody += "Ряд: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Row + "\n";
                                //    // место
                                //    strMailBody += "Место: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).SeatNum + "\n\n";
                                //    // цена билета
                                //    strMailBody += "Цена билета: " + (db.Seats.Where(seat => seat.Id == st.Id).FirstOrDefault()).Price + "\n\n";
                                //    strMailBody += "Вы можете выкупить билет при предъявлении этого уведомления " +
                                //        "в течение 24 часов с момента его получения." + "\n\n\n";
                                //    // подпись
                                //    strMailBody += "Отправлено из Playgoer " + DateTime.Now.ToString();
                                //}

                                //// e-mail
                                //try
                                //{
                                //    mailIndex = strFrom.IndexOf("@");
                                //    strFromCut = strFrom.Substring(0, mailIndex);
                                //    SmtpClient smtp1 = new SmtpClient("smtp.mail.ru", 25);
                                //    smtp1.Credentials = new NetworkCredential(strFromCut, pass);
                                //    MailMessage message = new MailMessage();
                                //    message.From = new MailAddress(strFrom, "Admin");
                                //    message.To.Add(new MailAddress((db.Users.Where(us => us.Login == usrLgn).FirstOrDefault()).Email));
                                //    message.Subject = strMailSubject;
                                //    message.Body = strMailBody;
                                //    smtp1.EnableSsl = true;
                                //    smtp1.Send(message);

                                //}
                                //catch
                                //{
                                //    mailFlag = false;
                                //    MessageBox.Show("Проверьте подключение к интернету"); ;
                                //}
                            }

                            //this.Close();
                        }
                    }

                    //if (mailFlag)
                    //{
                    //    MessageBox.Show("Уведомления отправлены");
                    //}

                    if (countReservedSeats == seatsList.Count())
                    {
                        MessageBox.Show("Места забронированы");
                    }
                    else
                    {
                        MessageBox.Show("Возникли проблемы с бронированием. Пожалуйста, повторите попытку");
                    }
                }
                else
                {
                    MessageBox.Show("Одно или несколько выбранных вами мест заняты");
                    foreach (var btn in btnsList)
                    {
                        btn.ClearValue(Button.BackgroundProperty);
                    }
                }

                seatsList.Clear();
                Model1 db2 = new Model1();

                ObservableCollection<Seat> seats = new ObservableCollection<Seat>();
                //List<Seat> seatsList = new List<Seat>();

                // Запрос на вывод значений мест, которых нет в таблице билетов
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@iiddPrf", selPerf.Id);

                // подзапрос выбирает Id занятых мест для выбранного спектакля 
                // далее из таблицы со сведениями обо всех местах выбираются только те, которые не были возвращены в подзапросе
                seatsList.AddRange(db2.Database.SqlQuery<Seat>("select * from Seats where Id not in(select SeatId from Tickets where PerformanceId = @iiddPrf) order by Sector desc, [Row], [SeatNum]", param));

                foreach (var item in seatsList)
                {
                    seats.Add(item);
                }                

                seatsGrid.ItemsSource = seats;
                seatsList.Clear();
                btnsList.Clear();
            }
            else
            {
                MessageBox.Show("Выберите места для бронирования");
            }
        }

        // Оплатить
        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (btnsList.Count() > 0)
            {
                foreach (var btn in btnsList)
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
                        }
                        else if ((btn.Name).Contains("B"))
                        {
                            rowStart = (btn.Name).IndexOf("B");
                            seatStart = (btn.Name).IndexOf("s");

                            string row = (btn.Name).Substring(rowStart + 1, seatStart - rowStart - 1);
                            string seatNum = (btn.Name).Substring(seatStart + 1);

                            seat = db.Seats.Where(s => s.Sector == "Балкон" && s.Row.ToString() == row && s.SeatNum.ToString() == seatNum).FirstOrDefault();
                            seatsList.Add(seat);
                        }
                        else
                        {
                            MessageBox.Show("error btnList");
                        }
                    }

                }

                int countTicksinDb = 0;

                // проверка на присутствие в бд билетов с выбранными сейчас местами
                foreach (var st in seatsList)
                {
                    using (Model1 db = new Model1())
                    {
                        if (db.Tickets.Where(tck => tck.SeatId == st.Id && tck.PerformanceId == selPerf.Id).FirstOrDefault() != null)
                        {
                            // количество билетов совпадающих с выбранными сейчас местами
                            countTicksinDb++;
                        }
                        //this.Close();
                    }
                }

                using (Model1 db = new Model1())
                {
                    // если в бд билетов не нашлось совпадений с выбранными сейчас местами, то можно оплачивать
                    if (countTicksinDb == 0)
                    {

                        this.Visibility = Visibility.Collapsed;
                        Pay pay = new Pay(usrLgn, btnsList, selPerf);
                        pay.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
                        pay.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Одно или несколько выбранных вами мест заняты");
                        foreach (var btn in btnsList)
                        {
                            btn.ClearValue(Button.BackgroundProperty);
                        }
                    }
                    //this.Close();
                }

                seatsList.Clear();
                Model1 db2 = new Model1();

                ObservableCollection<Seat> seats = new ObservableCollection<Seat>();
                //List<Seat> seatsList = new List<Seat>();

                // Запрос на вывод значений мест, которых нет в таблице билетов
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@iiddPrf", selPerf.Id);

                // подзапрос выбирает Id занятых мест для выбранного спектакля 
                // далее из таблицы со сведениями обо всех местах выбираются только те, которые не были возвращены в подзапросе
                seatsList.AddRange(db2.Database.SqlQuery<Seat>("select * from Seats where Id not in(select SeatId from Tickets where PerformanceId = @iiddPrf) order by Sector desc, [Row], [SeatNum]", param));

                foreach (var item in seatsList)
                {
                    seats.Add(item);
                }

                seatsGrid.ItemsSource = seats;
                seatsList.Clear();
                btnsList.Clear();                
            }
            else
                MessageBox.Show("Выберите места");
        }

        // Кнопка места
        private void btnSeat_Click(object sender, RoutedEventArgs e)
        {             
            // меняем цвет отправителя (кнопки) на жёлтый
            (sender as Button).Background = Brushes.Yellow;

            // btnsList - cписок выбранных мест
            // добавляем в список, если в нём нет; удаляем из списка, если есть там
            // добавление - нажали в 1й раз, удаление, когда нажали повторно                
            if (!btnsList.Contains(sender as Button))
                btnsList.Add(sender as Button);
            else
            {
                btnsList.Remove(sender as Button);
                (sender as Button).ClearValue(Button.BackgroundProperty);
            }
        }
    }
}
