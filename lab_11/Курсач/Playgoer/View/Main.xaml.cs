using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        
        private string usrLgn;
        private string usrNcknm;
        private string mail;
        private bool atoZ_SortingOrderFlagThtr = true, atoZ_SortingOrderFlagPerfGenre = true;

        List<Theater> thtrs = new List<Theater>();
        ObservableCollection<Theater> thtrsCollection = new ObservableCollection<Theater>();
        ObservableCollection<Theater> thtrsSourceCollection = new ObservableCollection<Theater>();
        ObservableCollection<Theater> middleThtrsCollection = new ObservableCollection<Theater>();
        ObservableCollection<Theater> middleThtrsCollection2 = new ObservableCollection<Theater>();
        ObservableCollection<Performance> perfs = new ObservableCollection<Performance>();
        ObservableCollection<Performance> perfsCollection = new ObservableCollection<Performance>();
        ObservableCollection<Performance> perfsSourceCollection = new ObservableCollection<Performance>();
        ObservableCollection<Performance> middlePerfsCollection = new ObservableCollection<Performance>();
        ObservableCollection<Performance> middlePerfsCollection2 = new ObservableCollection<Performance>();

        //public Main(string userNickname, string userLogin, string email)
        public Main()
        {
            InitializeComponent();
            
            // запуск в роли админа без авторизации
            usrLgn = "AdMiN";
            usrNcknm = "Admin";
            mail = "maria03052000@mail.ru";
            btnAddThtr.Visibility = Visibility.Visible;
            btnDelTh.Visibility = Visibility.Visible;
            btnAddPerf.Visibility = Visibility.Visible;
            btnDelPerf.Visibility = Visibility.Visible;

            // для запуска с логином и паролем, когда стартовая
            // страницв - MainWindow
            //usrLgn = Admin;
            //usrNcknm = userNickname;
            //mail = email;
            //if (userLogin.ToLower().Contains("admin") || userLogin.ToLower().Contains("админ"))
            //{
            //    btnAddThtr.Visibility = Visibility.Visible;
            //    btnDelTh.Visibility = Visibility.Visible;
            //    btnAddPerf.Visibility = Visibility.Visible;
            //    btnDelPerf.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    btnAddThtr.Visibility = Visibility.Collapsed;
            //    btnDelTh.Visibility = Visibility.Collapsed;
            //    btnAddPerf.Visibility = Visibility.Collapsed;
            //    btnDelPerf.Visibility = Visibility.Collapsed;
            //}            

            using (Model1 db = new Model1())
            {
                // загружаем данные
                db.Theaters.Load();
                // устанавливаем привязку к кэшу
                thrsGrid.ItemsSource = db.Theaters.Local.ToBindingList(); 

                db.Performances.Load();
                prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();
            }
        }

        // Купить билет
        private void btnTicketPay_Click(object sender, RoutedEventArgs e)
        {
            if (prfsGrid.SelectedItem != null)
            {
                this.Visibility = Visibility.Collapsed;
                PayorReserve payorReserve = new PayorReserve(usrLgn, (Performance)prfsGrid.SelectedItem, null);
                payorReserve.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; comboCity.Text = "Город"; };
                payorReserve.ShowDialog();
            }
            else
                MessageBox.Show("Сначала выберите спектакль, который хотите посетить");
        }

        // Моя страница
        private void btnUserPage_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            UserInfo userInfo = new UserInfo(usrNcknm, usrLgn, mail);
            userInfo.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; comboCity.Text = "Город"; };
            userInfo.ShowDialog();
        }

        // Подробнее о театре
        private void btnThInfo_Click(object sender, RoutedEventArgs e)
        {
            if (thrsGrid.SelectedItem != null)
            {
                this.Visibility = Visibility.Collapsed;
                TheaterInfo theaterInfo = new TheaterInfo((Theater)thrsGrid.SelectedItem);
                theaterInfo.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; comboCity.Text = "Город"; };
                theaterInfo.ShowDialog();
            }
            else
                MessageBox.Show("Для получения дополнительной информации сначала выберите театр");
        }

        // Подробнее о спектакле
        private void btnPerfInfo_Click(object sender, RoutedEventArgs e)
        {
            if (prfsGrid.SelectedItem != null)
            {
                this.Visibility = Visibility.Collapsed;
                PerformanceInfo performanceInfo = new PerformanceInfo(usrLgn, (Performance)prfsGrid.SelectedItem);
                performanceInfo.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; comboCity.Text = "Город"; };
                performanceInfo.ShowDialog();
            }
            else
                MessageBox.Show("Для получения дополнительной информации сначала выберите спектакль");
        }

        // Добавить театр
        private void btnAddThtr_Click(object sender, RoutedEventArgs e)
        {            
            this.Visibility = Visibility.Collapsed;
            AddTheater addTheater = new AddTheater();
            addTheater.Closed += (sender2, e2) => 
            { 
                this.Visibility = Visibility.Visible;
                using (Model1 db = new Model1())
                {
                    // загружаем данные
                    db.Theaters.Load();
                    // устанавливаем привязку к кэшу
                    thrsGrid.ItemsSource = db.Theaters.Local.ToBindingList();

                    db.Performances.Load();
                    prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();
                }
                comboCity.Text = "Город";
            };
            addTheater.ShowDialog();
        }

        // Удалить театр
        private void btnDelTh_Click(object sender, RoutedEventArgs e)
        {
            if (thrsGrid.SelectedItem != null)
            {
                Theater thtr = (Theater)thrsGrid.SelectedItem;

                using (Model1 db = new Model1())
                {
                    var theater = db.Theaters.FirstOrDefault(th => th.Id == thtr.Id);
                    if (theater != null)
                    {
                        db.Theaters.Remove(theater);
                        db.SaveChanges();
                        MessageBox.Show("Театр удалён");
                    }

                    
                        // загружаем данные
                        db.Theaters.Load();
                        // устанавливаем привязку к кэшу
                        thrsGrid.ItemsSource = db.Theaters.Local.ToBindingList();

                        db.Performances.Load();
                        prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();                    
                }
            }
            else
                MessageBox.Show("Выберите театр, который хотите удалить");
        }

        // Добавить спектакль
        private void btnAddPerf_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            AddPerformance addPerformance = new AddPerformance();
            addPerformance.Closed += (sender2, e2) => 
            { 
                this.Visibility = Visibility.Visible;
                using (Model1 db = new Model1())
                {
                    // загружаем данные
                    db.Theaters.Load();
                    // устанавливаем привязку к кэшу
                    thrsGrid.ItemsSource = db.Theaters.Local.ToBindingList();

                    db.Performances.Load();
                    prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();
                }
                comboCity.Text = "Город";
            };
            addPerformance.ShowDialog();
        }

        //Выбрать спектакли театра
        private void btnSelectedTh_Click(object sender, RoutedEventArgs e)
        {
            if (thrsGrid.SelectedItem != null)
            {
                using (Model1 db = new Model1())
                {
                    if (perfs.Count() > 0)
                    {
                        perfs.Clear();
                    }

                    foreach (var perf in db.Performances.Where(perf => perf.TheaterId == ((Theater)thrsGrid.SelectedItem).Id))
                    {
                        perfs.Add(perf);
                    }
                }

                if (perfs.Count() == 0)
                {
                    MessageBox.Show("В этом театре пока нет спектаклей");
                    prfsGrid.ItemsSource = perfs.ToList();
                }
                else
                    prfsGrid.ItemsSource = perfs.ToList();
            }
            else
                MessageBox.Show("Для получения дополнительной информации сначала выберите театр");
        }

        // Удалить спектакль
        private void btnDelPerf_Click(object sender, RoutedEventArgs e)
        {
            if (prfsGrid.SelectedItem != null)
            {
                Performance prf = (Performance)prfsGrid.SelectedItem;

                using (Model1 db = new Model1())
                {
                    var perf = db.Performances.FirstOrDefault(prfs => prfs.Id == prf.Id);
                    if (perf != null)
                    {
                        db.Performances.Remove(perf);
                        db.SaveChanges();
                        MessageBox.Show("Спектакль удалён");
                    }

                       // загружаем данные
                        db.Theaters.Load();
                        // устанавливаем привязку к кэшу
                        thrsGrid.ItemsSource = db.Theaters.Local.ToBindingList();

                        db.Performances.Load();
                        prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();
                    
                }
            }
            else
                MessageBox.Show("Выберите спектакль, который хотите удалить");
        }

        // Выбор города, в котором будет спектакль (меняются и театры, и спектакли)
        private void comboCity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            List<Performance> perfs = new List<Performance>();

            if (selectedItem.Content != null)
            {
                string selCity = selectedItem.Content.ToString();

                if (selCity != "Город")
                {
                    using (Model1 db = new Model1())
                    {
                        if (db.Theaters.Where(thtr => thtr.City == selCity).FirstOrDefault() != null)
                        {
                            if (thtrs.Count() > 0)
                            {
                                thtrs.Clear();
                            }
                            foreach (var th in db.Theaters.Where(thtr => thtr.City == selCity))
                            {
                                thtrs.Add(th);

                                foreach (var perf in db.Performances.Where(prf => prf.TheaterId == th.Id))
                                {
                                    perfs.Add(perf);
                                }
                            }

                            thrsGrid.ItemsSource = thtrs.ToList();
                            if (perfs.Count() == 0)
                            {
                                MessageBox.Show("В этом городе пока нет спектаклей");
                                prfsGrid.ItemsSource = perfs.ToList();
                            }
                            else
                                prfsGrid.ItemsSource = perfs.ToList();

                        }
                        else
                            MessageBox.Show("Для этого города театры ещё не добавлены");
                    }
                }
                else
                {
                    using (Model1 db = new Model1())
                    {
                        // загружаем данные
                        db.Theaters.Load();
                        // устанавливаем привязку к кэшу
                        thrsGrid.ItemsSource = db.Theaters.Local.ToBindingList();

                        db.Performances.Load();
                        prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();
                    }
                }
            }
        }

        // Показать все доступные спектакли, список театров не меняется
        private void btnAllPrfs_Click(object sender, RoutedEventArgs e)
        {
            using (Model1 db = new Model1())
            {
                db.Performances.Load();
                prfsGrid.ItemsSource = db.Performances.Local.ToBindingList();
            }
        }

        // Сортировка театров
        private void btnSortThtrs_Click(object sender, RoutedEventArgs e)
        {
            thtrsCollection.Clear();
            foreach (Theater th in thrsGrid.ItemsSource)
            {
                if (!thtrsCollection.Contains(th))
                {
                    thtrsCollection.Add(th);
                }
            }

            IOrderedEnumerable<Theater> result;

            if (atoZ_SortingOrderFlagThtr)
            {
                atoZ_SortingOrderFlagThtr = false;

                result = thtrsCollection.OrderByDescending(th => th.TName);

                middleThtrsCollection.Clear();
                foreach (Theater th in result)
                {
                    middleThtrsCollection.Add(th);
                }
                //foreach (var item in middleThtrsCollection)
                //{
                //    thtrsSourceCollection.Add(item);
                //}
                thtrsSourceCollection = middleThtrsCollection;
                thrsGrid.ItemsSource = thtrsSourceCollection.ToList();
            }
            else
            {
                atoZ_SortingOrderFlagThtr = true;

                result = thtrsCollection.OrderBy(th => th.TName);

                middleThtrsCollection2.Clear();
                foreach (Theater th in result)
                {
                    middleThtrsCollection2.Add(th);
                }
                thtrsSourceCollection = middleThtrsCollection2;
                thrsGrid.ItemsSource = thtrsSourceCollection;
            }
        }

        // Сортировка по жанрам
        private void btnSortGenrePrfs_Click(object sender, RoutedEventArgs e)
        {            
            perfsCollection.Clear();
            foreach (Performance prf in prfsGrid.ItemsSource)
            {
                if (!perfsCollection.Contains(prf))
                {
                    perfsCollection.Add(prf);
                }
            }

            IOrderedEnumerable<Performance> result;

            if (atoZ_SortingOrderFlagPerfGenre)
            {
                atoZ_SortingOrderFlagPerfGenre = false;

                result = perfsCollection.OrderByDescending(prf => prf.Genre).ThenByDescending(prf => prf.PName);

                middlePerfsCollection.Clear();
                foreach (Performance prf in result)
                {
                    middlePerfsCollection.Add(prf);
                }
                perfsSourceCollection = middlePerfsCollection;
                prfsGrid.ItemsSource = perfsSourceCollection.ToList();
            }
            else
            {
                atoZ_SortingOrderFlagPerfGenre = true;

                result = perfsCollection.OrderBy(prf => prf.Genre).ThenBy(prf => prf.PName);

                middlePerfsCollection2.Clear();
                foreach (Performance prf in result)
                {
                    middlePerfsCollection2.Add(prf);
                }
                perfsSourceCollection = middlePerfsCollection2;
                prfsGrid.ItemsSource = perfsSourceCollection.ToList();
            }
        }
    }
}
