using System;
using System.Linq;
using System.Windows;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private string forbiddenWord1 = "admin";
        private string forbiddenWord2 = "админ";

        public LogIn()
        {
            InitializeComponent();
        }

        private void buttonLogUp_Click(object sender, RoutedEventArgs e)
        {
            if ((nicknm.Text != "") && (lgn.Text != "") && (psw.Password != "") && (email.Text != ""))
            {
                using (Model1 db = new Model1())
                {
                    User us = db.Users.Where(u => u.Login == lgn.Text).FirstOrDefault();

                    if (us == null)
                    {
                        int ecount = 0;

                        foreach (char c in email.Text)
                        {
                            if (c == '@')
                            {
                                ecount++;
                            }
                        }

                        if (!lgn.Text.ToLower().Contains(forbiddenWord1) && !lgn.Text.ToLower().Contains(forbiddenWord2))
                        {
                            if (!nicknm.Text.ToLower().Contains(forbiddenWord1) && !nicknm.Text.ToLower().Contains(forbiddenWord2))
                            {
                                if (ecount == 1 && email.Text.Contains("mail."))
                                {
                                    User u = new User();
                                    u.Id = Guid.NewGuid();
                                    u.Nickname = nicknm.Text;
                                    u.Login = lgn.Text;
                                    u.Password = (psw.Password).GetHashCode().ToString();
                                    u.Email = email.Text;

                                    db.Users.Add(u);
                                    db.SaveChanges();

                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Недопустимый формат почты");
                            }
                            else
                                MessageBox.Show("Ник не должен содержать слова admin или админ вне зависимости от регистра");
                        }
                        else
                            MessageBox.Show("Логин не должен содержать слова admin или админ вне зависимости от регистра");
                    }
                    else
                        MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            else
                MessageBox.Show("Заполните все поля");
        }        
    }
}
