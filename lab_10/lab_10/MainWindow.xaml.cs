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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using lab_10.Classes;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Data;

namespace lab_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> studentsList = new ObservableCollection<Student>();
        ObservableCollection<Student> middleStudCollection = new ObservableCollection<Student>();
        ObservableCollection<Student> middleStudCollection2 = new ObservableCollection<Student>();
        //ObservableCollection<Address> addressesList = new ObservableCollection<Address>();
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string connectionString2 = ConfigurationManager.ConnectionStrings["NoDBConnection"].ConnectionString;
        public SqlConnection connection;

        bool atoZ_SortingOrderFlag = true;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();

                getDataFromDb();
            }
            catch (Exception)
            {
                SqlConnection myConn = new SqlConnection(connectionString2);

                string path = @"D:\4 сем\ООП 4 сем\ЛР\2\lab_10\lab_10_OOP_ADOdbcreator1.sql";
                using (FileStream fstream = File.OpenRead($"{path}"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(array);

                    SqlCommand myCommand = new SqlCommand(textFromFile, myConn);
                    try
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("DataBase is Created Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                string path2 = @"D:\4 сем\ООП 4 сем\ЛР\2\lab_10\lab_10_OOP_ADOdbcreator2.sql";
                using (FileStream fstream = File.OpenRead($"{path2}"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(array);

                    SqlCommand myCommand = new SqlCommand(textFromFile, myConn);
                    try
                    {
                        //myConn.Open();
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("Use DataBase Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                string path3 = @"D:\4 сем\ООП 4 сем\ЛР\2\lab_10\lab_10_OOP_ADOdbcreator3.sql";
                using (FileStream fstream = File.OpenRead($"{path3}"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(array);

                    SqlCommand myCommand = new SqlCommand(textFromFile, myConn);
                    try
                    {
                        //myConn.Open();
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("create procedure Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        if (myConn.State == ConnectionState.Open)
                        {
                            myConn.Close();
                        }
                    }
                }
            }            
        }

        private void getDataFromDb()
        {
            //MessageBox.Show("getDataFromDb()");
            try
            {             
                string sqlExpression2 = "SELECT * FROM Students";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression2, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        printer.ItemsSource = null;

                        studentsList.Clear();

                        while (reader.Read()) // построчно считываем данные
                        {
                            string surn = reader.GetString(0);
                            string name = reader.GetString(1);
                            string patr = reader.GetString(2);
                            int age = reader.GetInt32(3);
                            string spec = reader.GetString(4);
                            DateTime dateBirth = (DateTime)reader.GetValue(5);
                            int course = reader.GetInt32(6);
                            int group = reader.GetInt32(7);
                            double avMark = reader.GetDouble(8);
                            string gender = reader.GetString(9);
                            int addrId = reader.GetInt32(10);
                            byte[] photoBytes = (byte[])reader.GetValue(11);

                            ImageSource photo = Helper.ByteToImage(photoBytes);
                            Student student = new Student(surn, name, patr, age, spec, dateBirth, course, group,
                                avMark, gender, addrId, photo);
                            studentsList.Add(student);
                            printer.ItemsSource = studentsList;
                            //MessageBox.Show(studentsList.Count + " " + studentsList.FirstOrDefault().Surname);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            if (printer.SelectedIndex == -1) printer.SelectedIndex = 0;
            else if (printer.SelectedIndex != 0) printer.SelectedIndex -= 1;
            printer.ScrollIntoView(printer.SelectedItem);

            
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            if (printer.SelectedIndex == -1) printer.SelectedIndex = 0;
            else if (printer.SelectedIndex != printer.Items.Count - 1) printer.SelectedIndex += 1;
            printer.ScrollIntoView(printer.SelectedItem);
        }

        // add student
        private void addStudButton_Click(object sender, RoutedEventArgs e)
        {            
            StudEditor studEditor = new StudEditor(true);
            studEditor.Closed += (sender2, e2) => { getDataFromDb(); };
            studEditor.ShowDialog();
            
        }

        // edit stud info
        private void editStudButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            
            StudEditor studEditor = new StudEditor(false, (Student)printer.SelectedItem);
            // address left or change with button
            // присвоить переданный адрес на случай, если ничего не меняется
            studEditor.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; getDataFromDb(); };
            studEditor.ShowDialog();
        }

        // delete stud
        private void compDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (printer.SelectedIndex > -1)
                {
                    string sqlExpression = "delete FROM Students where surname=@surname";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        SqlParameter surnameParam = new SqlParameter("@surname", ((Student)printer.SelectedItem).Surname);
                        command.Parameters.Add(surnameParam);

                        command.ExecuteNonQuery();
                    }

                    getDataFromDb();
                    // remove from db
                    //studentsList.Remove((Student)printer.SelectedItem);
                }
                else
                    MessageBox.Show("Выберите студента");

                
                //students = newListStudents;
                //printer.ItemsSource = studentsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // Подробнее
        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;

            DetailsWindow detailsWindow = new DetailsWindow((Student)printer.SelectedItem);
            detailsWindow.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
            detailsWindow.ShowDialog();
        }

        // sort
        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IOrderedEnumerable<Student> result;

                if (atoZ_SortingOrderFlag)
                {
                    atoZ_SortingOrderFlag = false;

                    result = studentsList.OrderByDescending(st => st.Surname);

                    middleStudCollection.Clear();
                    foreach (Student stud in result)
                    {
                        middleStudCollection.Add(stud);
                    }
                    studentsList = middleStudCollection;
                    printer.ItemsSource = studentsList;
                }                    
                else
                {
                    atoZ_SortingOrderFlag = true;

                    result = studentsList.OrderBy(st => st.Surname);
                    
                    middleStudCollection2.Clear();
                    foreach (Student stud in result)
                    {
                        middleStudCollection2.Add(stud);
                    }
                    studentsList = middleStudCollection2;
                    printer.ItemsSource = studentsList;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }



        //private void addImageButton_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog fileDialog = new OpenFileDialog();

        //    bool? result = fileDialog.ShowDialog();
        //    if (result == true)
        //    {
        //        string filename = fileDialog.FileName;
        //        //MessageBox.Show(filename);
        //        image.Source = new BitmapImage(new Uri(filename, UriKind.Absolute)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };;
        //        Helper.ConvertImageIntoBytes(filename);
        //        // получаем данные их БД
        //        List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
        //        List<string> iScreen_format = new List<string>();
        //        using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=dbtest;Integrated Security=True"))
        //        {
        //            sqlConnection.Open();
        //            SqlCommand sqlCommand = new SqlCommand();
        //            sqlCommand.Connection = sqlConnection;
        //            sqlCommand.CommandText = @"SELECT [screen], [screen_format] FROM [report] WHERE [id] = 4"; // наша запись в БД под id=1, поэтому в запросе "WHERE [id] = 1"
        //            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
        //            byte[] iTrimByte = null;
        //            string iTrimText = null;
        //            while (sqlReader.Read()) // считываем и вносим в лист результаты
        //            {
        //                iTrimByte = (byte[])sqlReader["screen"]; // читаем строки с изображениями
        //                iScreen.Add(iTrimByte);
        //                iTrimText = sqlReader["screen_format"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображения
        //                iScreen_format.Add(iTrimText);
        //            }
        //            sqlConnection.Close();
        //        }
        //        image2.Source= Helper.ByteToImage(iScreen.Last());
        //    }

        //}


    }
}
