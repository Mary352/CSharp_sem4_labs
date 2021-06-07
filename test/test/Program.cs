using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Drawing; // в References подключить одноимённую библиотеку
using System.Configuration;

namespace test
{
    class Program
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection connection;

        static void Main(string[] args)
        {

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            
            string path = @"D:\4 сем\ООП 4 сем\ЛР\2\test\testdbCreator.sql";
            using (FileStream fstream = File.OpenRead($"{path}"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                SqlCommand myCommand = new SqlCommand(textFromFile, myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("DataBase is Created Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                //finally
                //{
                //    if (myConn.State == ConnectionState.Open)
                //    {
                //        myConn.Close();
                //    }
                //}
            }

            string path2 = @"D:\4 сем\ООП 4 сем\ЛР\2\test\testdbCreator2.sql";
            using (FileStream fstream = File.OpenRead($"{path2}"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                SqlCommand myCommand = new SqlCommand(textFromFile, myConn);
                try
                {
                    //myConn.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("Use DataBase Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                //finally
                //{
                //    if (myConn.State == ConnectionState.Open)
                //    {
                //        myConn.Close();
                //    }
                //}
            }

            //           string sqlExpression2 = "CREATE PROCEDURE [dbo].[sp_InsertStudent2] @surname nvarchar(50), @name nvarchar(50), @patronymic nvarchar(50),"+
            //"@age int, @speciality nvarchar(50), @dateBirth date, @course int, @group int, @averageMark float, @gender nvarchar(50), @address int,"+
            //   "@photo image AS INSERT INTO Students(Surname, [Name], Patronymic, Age, Speciality, DateBirth, Course, [Group], AverageMark, Gender,"+
            //   "[Address], Photo) VALUES(@surname, @name, @patronymic, @age, @speciality, @dateBirth, @course, @group, @averageMark, @gender, @address, @photo)";
            //           using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            //           {
            //               connection.Open();
            //               SqlCommand command = new SqlCommand(sqlExpression2, connection);
            //               command.ExecuteNonQuery();
            //           }
            string path3 = @"D:\4 сем\ООП 4 сем\ЛР\2\test\testdbCreator3.sql";
            using (FileStream fstream = File.OpenRead($"{path3}"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");

                SqlCommand myCommand = new SqlCommand(textFromFile, myConn);
                try
                {
                    //myConn.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("create procedure Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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
}
