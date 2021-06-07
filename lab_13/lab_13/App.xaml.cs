using lab_13.Model;
using lab_13.View;
using lab_13.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace lab_13
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private void OnStartup(object sender, StartupEventArgs e)
        //{
        //    List<Lecturer> lecturers = new List<Lecturer>();
        //    //List<Book> books = new List<Book>()
        //    //{
        //    //    new Book("Пттерны проетирования", "John Gossman", 3),
        //    //    new Book("CLR via C#", "Джеффри Рихтер", 2),
        //    //    new Book("Исскуство программирования", "Кнут", 2)
        //    //};

        //    MainWindow mainWnd = new MainWindow(); // создали View
        //    MainViewModel viewModel = new ViewModel.MainViewModel(lecturers); // Создали ViewModel
        //    mainWnd.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
        //    mainWnd.Show();
        //}
    }
}
