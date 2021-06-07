using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для AddTheater.xaml
    /// </summary>
    public partial class AddTheater : Window
    {
        public AddTheater()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if ((thNameBox.Text != "") && (city.Text != "") && (adress.Text != "") && (phone.Text != ""))
            {
                int ph;

                bool success = int.TryParse(phone.Text, out ph);

                if (success)
                {
                    Theater ths = new Theater();
                    using (Model1 db = new Model1())
                    {
                        ths = db.Theaters.Where(th => th.TName == thNameBox.Text).FirstOrDefault();
                    }

                    if (ths == null)
                        {
                            Theater thtr = new Theater();
                            thtr.Id = Guid.NewGuid();
                            thtr.TName = thNameBox.Text;
                            thtr.City = city.Text;
                            thtr.Address = adress.Text;
                            thtr.Phone = phone.Text;

                            //db.Theaters.Add(thtr);
                            //db.SaveChanges();
                            Task t = SaveObjectsAsync(thtr);
                            //t.Wait();
                            //SaveObjectsAsync(thtr).Wait();

                            MessageBox.Show("Театр успешно добавлен");
                            thNameBox.Text = "";
                            city.Text = "";
                            adress.Text = "";
                            phone.Text = "";

                            //this.Close();
                        }
                        else
                            MessageBox.Show("Этот театр уже есть");
                    
                }
                else
                    MessageBox.Show("Номер телефона указывать в числовом формате без различных символов и длиной до 10 знаков");
            }
            else
                MessageBox.Show("Заполните все поля");
        }

        private static async Task SaveObjectsAsync(Theater thtr)
        {
            using (Model1 db = new Model1())
            {
                db.Theaters.Add(thtr);
                await db.SaveChangesAsync();
            }
            //Theater thtr = new Theater();
            //thtr.Id = Guid.NewGuid();
            //thtr.TName = thNameBox.Text;
            //thtr.City = city.Text;
            //thtr.Address = adress.Text;
            //thtr.Phone = phone.Text;

                       
            
        }
    }
}
