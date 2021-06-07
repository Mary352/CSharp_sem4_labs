using lab_10.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lab_10
{
    /// <summary>
    /// Логика взаимодействия для DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public Student ConcreteStudent { get; set; }

        ObservableCollection<Address> addressesList = new ObservableCollection<Address>();

        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection connection;

        public DetailsWindow(Student student)
        {
            InitializeComponent();

            ConcreteStudent = new Student
            {
                Surname = student.Surname,
                Name = student.Name,
                Patronymic = student.Patronymic,
                Age = student.Age,
                Speciality = student.Speciality,
                DateBirth = student.DateBirth,
                Course = student.Course,
                Group = student.Group,
                AverageMark = student.AverageMark,
                Gender = student.Gender,
                AddressId = student.AddressId,
                Photo = student.Photo
            };

            this.DataContext = ConcreteStudent;

            string sqlExpression1 = "SELECT * FROM Addresses";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression1, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    addressesList.Clear();

                    while (reader.Read()) // построчно считываем данные
                    {
                        int addressId = reader.GetInt32(0);
                        string city = reader.GetString(1);
                        string postcode = reader.GetString(2);
                        string street = reader.GetString(3);
                        string house = reader.GetString(4);
                        string apt = reader.GetString(5);

                        Address address = new Address(addressId, city, postcode, street, house, apt);
                        addressesList.Add(address);
                    }
                }
            }           

            foreach (Address address in addressesList)
            {
                if ((address.AddrId).Equals(student.AddressId))
                {
                    cityTxtBlk.Text = address.City;
                    postcodeTxtBlk.Text = address.Postcode;
                    streetTxtBlk.Text = address.Street;
                    houseTxtBlk.Text = address.House;
                    aptTxtBlk.Text = address.Apt;                 
                }
            }
        }
    }
}
