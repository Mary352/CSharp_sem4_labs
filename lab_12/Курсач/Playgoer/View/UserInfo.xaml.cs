using Playgoer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Window
    {
        private string usrLgn;
        private string usrNcknm;
        private string mail;
        private Guid usrId;

        public UserInfo(string userNickname, string userLogin, string email)
        {
            InitializeComponent();

            usrLgn = userLogin;
            usrNcknm = userNickname;
            mail = email;

            if (userLogin.ToLower().Contains("admin") || userLogin.ToLower().Contains("админ"))
            {
                bthUsersManger.Visibility = Visibility.Visible;
            }
            else
            {
                bthUsersManger.Visibility = Visibility.Collapsed;
            }

            usrNicknameBlock.Text = userNickname;
            usrEmailBlock.Text = email;

            List<HelpPerf> listHelpPerf = new List<HelpPerf>();

            using (Model1 db = new Model1())
            {
                usrId = (db.Users.Where(us => us.Login == userLogin).FirstOrDefault()).Id;
                var ticks = db.Tickets.Where(tk => tk.UserId == usrId);

                foreach(Ticket tick in ticks)
                {
                    HelpPerf helpPerf = new HelpPerf();
                    helpPerf.PName = db.Performances.Find(tick.PerformanceId).PName;
                    helpPerf.PDate = db.Performances.Find(tick.PerformanceId).Date_time.Date.ToString("d");
                    helpPerf.PTime = db.Performances.Find(tick.PerformanceId).Date_time.TimeOfDay.ToString();

                    listHelpPerf.Add(helpPerf);
                }
            }

            ticksGrid.ItemsSource = listHelpPerf;
        }

        // Выбрать спектакль
        private void btnGoToMainPage_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Список пользователей
        private void bthUsersManger_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            UsersManager usersManager = new UsersManager(usrLgn);
            usersManager.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
            usersManager.ShowDialog();
        }

        // Изменить e-mail
        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            ChangeMail changeMail = new ChangeMail(usrLgn);
            changeMail.Closed += (sender2, e2) => 
            {
                using (Model1 db = new Model1())
                {
                    User us = db.Users.Where(u => u.Login == usrLgn).FirstOrDefault();
                    mail = us.Email;
                }
                    usrEmailBlock.Text = mail;
                this.Visibility = Visibility.Visible; 
            };
            changeMail.ShowDialog();
        }
    }
}
