using lab_10.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace lab_10
{
    /// <summary>
    /// Логика взаимодействия для StudEditor.xaml
    /// </summary>
    public partial class StudEditor : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection connection;
        SqlTransaction transaction;
        SqlCommand command;

        //ObservableCollection<int> addresses = new ObservableCollection<int>();
        private int addrId;
        private string filename, surnameKey;
        private bool newStudFlag;

        public StudEditor(bool newStudFlag)
        {
            InitializeComponent();

            this.newStudFlag = newStudFlag;

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                transaction = connection.BeginTransaction();

                command = connection.CreateCommand();
                command.Transaction = transaction;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // true -> new stud
        }

        public StudEditor(bool newStudFlag, Student student)
        {
            InitializeComponent();

            this.newStudFlag = newStudFlag;

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                transaction = connection.BeginTransaction();

                command = connection.CreateCommand();
                command.Transaction = transaction;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            surnameKey = student.Surname;

            surnameTxtB.Text = student.Surname;            
            nameTxtB.Text = student.Name;
            patronTxtB.Text = student.Patronymic;
            ageTxtB.Text = student.Age.ToString();
            specCmbB.Text = student.Speciality;
            dateBirthPicker.SelectedDate = student.DateBirth;
            courseCmbB.Text = student.Course.ToString();
            groupCmbB.Text = student.Group.ToString();
            avgMarkTxtB.Text = student.AverageMark.ToString();
            genderCmbB.Text = student.Gender;
            addrId = student.AddressId;

            // false -> edit stud
        }

        // add address
        private void addrButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            AddressEditor addrEditor = new AddressEditor();
            addrEditor.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
            var result = addrEditor.ShowDialog();
            if (result == true)
                addrId = addrEditor.AddressId;            
        }

        // save
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(saveandCloseChB.IsChecked == true)
            {
                // save transaction and close
                try
                {
                    transaction.Commit();
                    MessageBox.Show("add students ok");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
                
                this.Close();
            }
            else
            {
                if (newStudFlag)
                {
                    try
                    {
                        // add new student
                        string sqlExpression = "sp_InsertStudent";
                        command.CommandText = sqlExpression;
                        //SqlCommand command = new SqlCommand(sqlExpression, connection);
                        // указываем, что команда представляет хранимую процедуру
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // параметр для ввода surname
                        SqlParameter surnameParam = new SqlParameter("@surname", surnameTxtB.Text);
                        command.Parameters.Add(surnameParam);

                        // параметр для ввода name
                        SqlParameter nameParam = new SqlParameter("@name", nameTxtB.Text);
                        command.Parameters.Add(nameParam);

                        // параметр для ввода patronymic
                        SqlParameter patronymicParam = new SqlParameter("@patronymic", patronTxtB.Text);
                        command.Parameters.Add(patronymicParam);

                        // параметр для ввода возраста
                        int age = 0;
                        try
                        {
                            age = Convert.ToInt32(ageTxtB.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "age error");
                            throw new FormatException();
                        }
                        SqlParameter ageParam = new SqlParameter("@age", age);
                        command.Parameters.Add(ageParam);

                        // параметр для ввода speciality
                        SqlParameter specialityParam = new SqlParameter("@speciality", specCmbB.Text);
                        //MessageBox.Show("speciality: " + specCmbB.Text);
                        command.Parameters.Add(specialityParam);

                        SqlParameter dateBirthParam = new SqlParameter("@dateBirth", dateBirthPicker.SelectedDate);
                        command.Parameters.Add(dateBirthParam);

                        int course = 0;
                        try
                        {
                            course = Convert.ToInt32(courseCmbB.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "course error");
                            throw new FormatException();
                        }
                        SqlParameter courseParam = new SqlParameter("@course", course);
                        command.Parameters.Add(courseParam);

                        int group = 0;
                        try
                        {
                            group = Convert.ToInt32(groupCmbB.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "group error");
                            throw new FormatException();
                        }
                        SqlParameter groupParam = new SqlParameter("@group", group);
                        command.Parameters.Add(groupParam);

                        double averageMark = 0;
                        try
                        {
                            averageMark = Convert.ToDouble(avgMarkTxtB.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "averageMark error");
                            throw new FormatException();
                        }
                        SqlParameter averageMarkParam = new SqlParameter("@averageMark", averageMark);
                        command.Parameters.Add(averageMarkParam);

                        SqlParameter genderParam = new SqlParameter("@gender", genderCmbB.Text);
                        command.Parameters.Add(genderParam);

                        SqlParameter addressParam = new SqlParameter("@address", addrId);
                        command.Parameters.Add(addressParam);

                        SqlParameter photoParam = new SqlParameter("@photo", Helper.ConvertImageIntoBytes(filename));
                        command.Parameters.Add(photoParam);
                        
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        MessageBox.Show("add stud ok");
                    }
                    catch(FormatException)
                    {
                        command.Parameters.Clear();
                        MessageBox.Show("Заполните все поля, в т.ч. адрес");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " ---Заполните все поля, в т.ч. адрес---");
                    }
                }
                else
                {
                    try
                    {
                        // upd student
                        string sqlExpression = "UPDATE Students SET [Name] = @name, Patronymic = @patronymic, Age = @age, Speciality = @speciality, " +
                            "DateBirth=@dateBirth, Course=@course, [Group]=@group, AverageMark=@averageMark, Gender=@gender, [Address]=@address " +
                            "WHERE Surname=@surname";
                        try
                        {
                            command.CommandText = sqlExpression;
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + " ---COMMAND---"); ;
                        }

                        // параметр для ввода surname
                        // surname - primary key, поэтому игнорируем любое значение в surnameTxtB                        
                        SqlParameter surnameParam = new SqlParameter("@surname", surnameKey);
                        command.Parameters.Add(surnameParam);

                        // параметр для ввода name
                        if (nameTxtB.Text != "")
                        {
                            SqlParameter nameParam = new SqlParameter("@name", nameTxtB.Text);
                            command.Parameters.Add(nameParam);
                        }

                        // параметр для ввода patronymic
                        if (patronTxtB.Text != "")
                        {
                            SqlParameter patronymicParam = new SqlParameter("@patronymic", patronTxtB.Text);
                            command.Parameters.Add(patronymicParam);
                        }

                        // параметр для ввода возраста
                        if (ageTxtB.Text != "")
                        {
                            int age = 0;
                            try
                            {
                                age = Convert.ToInt32(ageTxtB.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "age error");
                            }
                            SqlParameter ageParam = new SqlParameter("@age", age);
                            command.Parameters.Add(ageParam);
                        }

                        // параметр для ввода speciality
                        if (ageTxtB.Text != "")
                        {
                            SqlParameter specialityParam = new SqlParameter("@speciality", specCmbB.Text);
                            command.Parameters.Add(specialityParam);
                        }

                        if (dateBirthPicker.SelectedDate != null)
                        {
                            SqlParameter dateBirthParam = new SqlParameter("@dateBirth", dateBirthPicker.SelectedDate);
                            command.Parameters.Add(dateBirthParam);
                        }

                        if (courseCmbB.Text != "")
                        {
                            int course = 0;
                            try
                            {
                                course = Convert.ToInt32(courseCmbB.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "course error");
                            }
                            SqlParameter courseParam = new SqlParameter("@course", course);
                            command.Parameters.Add(courseParam);
                        }

                        if (groupCmbB.Text != "")
                        {
                            int group = 0;
                            try
                            {
                                group = Convert.ToInt32(groupCmbB.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "group error");
                            }
                            SqlParameter groupParam = new SqlParameter("@group", group);
                            command.Parameters.Add(groupParam);
                        }

                        if (avgMarkTxtB.Text != "")
                        {
                            double averageMark = 0;
                            try
                            {
                                averageMark = Convert.ToDouble(avgMarkTxtB.Text);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "averageMark error");
                            }
                            SqlParameter averageMarkParam = new SqlParameter("@averageMark", averageMark);
                            command.Parameters.Add(averageMarkParam);
                        }

                        if (genderCmbB.Text != "")
                        {
                            SqlParameter genderParam = new SqlParameter("@gender", genderCmbB.Text);
                            command.Parameters.Add(genderParam);
                        }

                        // id адреса остаётся старым, если не нажать на кнопку адреса и не создать новый
                        // тогда в бд добавится новый адрес
                        SqlParameter addressParam = new SqlParameter("@address", addrId);
                        command.Parameters.Add(addressParam);

                        if (photoTxtB.Text != "")
                        {
                            SqlParameter photoParam = new SqlParameter("@photo", Helper.ConvertImageIntoBytes(filename));
                            command.Parameters.Add(photoParam);
                        }

                        command.ExecuteNonQuery();

                        MessageBox.Show("upd stud ok");

                        try
                        {
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }

                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " ---Заполните все поля---");
                    }
                }
                
            }
        }

        // + photo
        private void photoFilesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            bool? result = fileDialog.ShowDialog();
            if (result == true)
            {
                filename = fileDialog.FileName;
                photoTxtB.Text = filename;
                
                //MessageBox.Show(filename);
                //image.Source = new BitmapImage(new Uri(filename, UriKind.Absolute)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache }; ;

                //// получаем данные их БД
                //List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
                //List<string> iScreen_format = new List<string>();
                //using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=dbtest;Integrated Security=True"))
                //{
                //    sqlConnection.Open();
                //    SqlCommand sqlCommand = new SqlCommand();
                //    sqlCommand.Connection = sqlConnection;
                //    sqlCommand.CommandText = @"SELECT [screen], [screen_format] FROM [report] WHERE [id] = 4"; // наша запись в БД под id=1, поэтому в запросе "WHERE [id] = 1"
                //    SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                //    byte[] iTrimByte = null;
                //    string iTrimText = null;
                //    while (sqlReader.Read()) // считываем и вносим в лист результаты
                //    {
                //        iTrimByte = (byte[])sqlReader["screen"]; // читаем строки с изображениями
                //        iScreen.Add(iTrimByte);
                //        iTrimText = sqlReader["screen_format"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображения
                //        iScreen_format.Add(iTrimText);
                //    }
                //    sqlConnection.Close();
                //}
                //image2.Source = Helper.ByteToImage(iScreen.Last());
            }
        }
    }
}
