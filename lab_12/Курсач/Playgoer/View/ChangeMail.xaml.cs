using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeMail.xaml
    /// </summary>
    public partial class ChangeMail : Window
    {
        private string usrlgn;

        public ChangeMail(string userLogin)
        {
            InitializeComponent();
            usrlgn = userLogin;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (mailBox.Text != "")
            {
                using (Model1 db = new Model1())
                {
                    User us = db.Users.Where(u => u.Login == usrlgn).FirstOrDefault();

                    if (us != null)
                    {
                        int ecount = 0;

                        foreach (char c in mailBox.Text)
                        {
                            if (c == '@')
                            {
                                ecount++;
                            }
                        }

                        if (ecount == 1 && mailBox.Text.Contains("mail."))
                        {                           
                            
                            us.Email = mailBox.Text;

                            
                            db.SaveChanges();

                            MessageBox.Show("E-mail изменён успешно");
                            this.Close();
                        }
                        else
                            MessageBox.Show("Недопустимый формат почты");
                    }
                    else
                        MessageBox.Show("Ошибка. Вы не можете поменять почту");
                }
            }
            else
                MessageBox.Show("Введите новый e-mail");
        }
    }
}
