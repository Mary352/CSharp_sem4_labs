using System;
using System.Linq;
using System.Windows;
using Playgoer.View;

namespace Playgoer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //// Добавление админа, если его нет, сразу по открытии приложения
            //using (Model1 db = new Model1())
            //{
            //    var users = db.Users;

            //    if (users.Count() == 0)
            //    {
            //        User u = new User();
            //        u.Id = Guid.NewGuid();
            //        u.Nickname = "Admin";
            //        u.Login = "AdMiN";
            //        #region
            //        u.Password = "AdMiN7519ha".GetHashCode().ToString();
            //        #endregion
            //        u.Email = "maria03052000@mail.ru";

            //        db.Users.Add(u);
            //        db.SaveChanges();
            //    }
            //}
        }

        //// Войти
        //private void LogUpButton_Click(object sender, RoutedEventArgs e)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        if ((lgn.Text != "") && (pswd.Password != ""))
        //        {
        //            User user = db.Users.Where(u => u.Login == lgn.Text).FirstOrDefault();

        //            if (user != null && user.Password == pswd.Password.GetHashCode().ToString())
        //            {
        //                lgn.Text = "";
        //                pswd.Password = "";
        //                this.Visibility = Visibility.Collapsed;
        //                Main main = new Main(user.Nickname, user.Login, user.Email);
        //                main.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
        //                main.ShowDialog();
        //            }
        //            else
        //                MessageBox.Show("Неверный логин или пароль. Если вы не зарегистрированы, зарегистрируйтесь нажав на кнопку Регистрация");
        //        }
        //        else
        //            MessageBox.Show("Заполните все поля");
        //    }
        //}

        //// Регистрация
        //private void LogInButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Visibility = Visibility.Collapsed;
        //    LogIn logIn = new LogIn();
        //    logIn.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
        //    logIn.ShowDialog();
        //}
    }
}
