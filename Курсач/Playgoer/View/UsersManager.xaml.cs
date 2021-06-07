using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для UsersManager.xaml
    /// </summary>
    public partial class UsersManager : Window
    {
        private string usrLgn;

        public UsersManager(string userLgn)
        {
            InitializeComponent();

            usrLgn = userLgn;

            using (Model1 db = new Model1())
            {
                // загружаем данные
                db.Users.Load();
                // устанавливаем привязку к кэшу
                usrsGrid.ItemsSource = db.Users.Local.ToBindingList();
            }
        }

        // Добавить пользователя
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            AddUser addUser = new AddUser();
            addUser.Closed += (sender2, e2) => 
            { 
                this.Visibility = Visibility.Visible;
                using (Model1 db = new Model1())
                {
                    // загружаем данные
                    db.Users.Load();
                    // устанавливаем привязку к кэшу
                    usrsGrid.ItemsSource = db.Users.Local.ToBindingList();
                }
            };
            addUser.ShowDialog();
        }

        // Удалить пользователя
        private void btnDelUser_Click(object sender, RoutedEventArgs e)
        {
            if (usrsGrid.SelectedItem != null)
            {
                User usr = (User)usrsGrid.SelectedItem;

                using (Model1 db = new Model1())
                {
                    // Логин выбранного пользователя не совпадает с текущим логином
                    // на случай, если у админа будут пользоваатели-помощники с никами включающими слова admin или админ в разных регистрах
                    if (usr.Login != usrLgn)
                    {
                        var user = db.Users.FirstOrDefault(us => us.Id == usr.Id);
                        if (user != null)
                        {
                            db.Users.Remove(user);
                            db.SaveChanges();
                            MessageBox.Show("Пользователь удалён");


                            // загружаем данные
                            db.Users.Load();
                            // устанавливаем привязку к кэшу
                            usrsGrid.ItemsSource = db.Users.Local.ToBindingList();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не можете удалить свою учётную запись");
                    }
                }
            }
            else
                MessageBox.Show("Выберите пользователя, которого хотите удалить");
        }
    }
}
