using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using lab_10.Classes;

namespace lab_10
{
    /// <summary>
    /// Логика взаимодействия для AddressEditor.xaml
    /// </summary>
    public partial class AddressEditor : Window
    {
        public Address address;
        public int AddressId {get;set;}
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection connection;

        public AddressEditor()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show("Ok there. Begin");
                // запрос с параметрами
                string sqlExpression = "INSERT INTO Addresses (AddressId, City, Postcode, Street, House, Apt) " +
                "VALUES (@id, @city, @postcode, @street, @house, @apt)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    Random rnd = new Random();
                    AddressId = rnd.Next(0, 1000) + rnd.Next(1000, 2345) + rnd.Next(2400, 4006);

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    // создаем параметр для addrId
                    SqlParameter addrIdParam = new SqlParameter("@id", AddressId);
                    // добавляем параметр к команде
                    command.Parameters.Add(addrIdParam);

                    // создаем параметр для city
                    SqlParameter cityParam = new SqlParameter("@city", cityTxtB.Text);
                    command.Parameters.Add(cityParam);

                    // создаем параметр для postcode
                    SqlParameter postcodeParam = new SqlParameter("@postcode", postcodeTxtB.Text);
                    command.Parameters.Add(postcodeParam);

                    // создаем параметр для street
                    SqlParameter streetParam = new SqlParameter("@street", streetTxtB.Text);
                    command.Parameters.Add(streetParam);

                    // создаем параметр для house
                    SqlParameter houseParam = new SqlParameter("@house", houseTxtB.Text);
                    command.Parameters.Add(houseParam);

                    // создаем параметр для apt
                    SqlParameter aptParam = new SqlParameter("@apt", aptTxtB.Text);
                    command.Parameters.Add(aptParam);

                    int number = command.ExecuteNonQuery();
                    MessageBox.Show("add address ok");
                    //MessageBox.Show("Добавлено объектов: {0}", number); // 1
                    
                    //MessageBox.Show("before close AddressId: " + AddressId);
                    DialogResult = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ---add address error---");
            }
            
        }
    }
}
