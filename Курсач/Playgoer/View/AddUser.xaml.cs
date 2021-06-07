using System;
using System.Linq;
using System.Windows;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        
        public AddUser()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((Ncknm.Text != "") && (login.Text != "") && (pswd.Password != "") && (email.Text != ""))
            {
                using (Model1 db = new Model1())
                {
                    User us = db.Users.Where(u => u.Login == login.Text).FirstOrDefault();

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

                        if (ecount == 1 && email.Text.Contains("mail."))
                        {
                            using (var transaction = db.Database.BeginTransaction())
                            {
                                try
                                {                                
                                    User u = new User();
                                    u.Id = Guid.NewGuid();
                                    u.Nickname = Ncknm.Text;
                                    u.Login = login.Text;
                                    u.Password = (pswd.Password).GetHashCode().ToString();
                                    u.Email = email.Text;

                                    db.Database.ExecuteSqlCommand(@"select * from Users"); // select * from Users
                                    db.Users.Add(u);
                                    db.SaveChanges();
                                    transaction.Commit();

                                    MessageBox.Show("Добавлен новый пользователь");
                                    Ncknm.Text = "";
                                    login.Text = "";
                                    pswd.Password = "";
                                    email.Text = "";
                                    //this.Close();
                                }
                                catch (Exception ex)
                                {

                                    transaction.Rollback();
                                    MessageBox.Show(ex.Message + "Rollback");
                                }
                            }
                            
                        }
                        else
                            MessageBox.Show("Недопустимый формат почты");
                    }
                    else
                        MessageBox.Show("Этот логин уже занят");
                }
            }
            else
                MessageBox.Show("Заполните все поля");
        }
    }
}
