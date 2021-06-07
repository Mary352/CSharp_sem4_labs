using lab_6_9.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_6_9
{
    public class WindowCommands
    {
        static WindowCommands()
        {
            SearchItem = new RoutedUICommand("Search with searchbox, ignore filter", "SearchItem", typeof(MainWindow));

            Undo = new RoutedCommand("Undo", typeof(MainWindow));
            Redo = new RoutedCommand("Redo", typeof(MainWindow));
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
            SaveList = new RoutedCommand("SaveList", typeof(MainWindow));
            DeleteItem = new RoutedCommand("DeleteItem", typeof(MainWindow));
            EditItem = new RoutedCommand("EditItem", typeof(MainWindow));
            FilterSearch = new RoutedCommand("FilterSearch", typeof(MainWindow));            
            CloseBookDetails = new RoutedCommand("CloseBookDetails", typeof(BookDetails));
            OpenAddBookWindow = new RoutedCommand("OpenAddBookWindow", typeof(AddBook));
            AddFormat = new RoutedCommand("AddFormat", typeof(AddBook));
            SaveItem = new RoutedCommand("SaveItem", typeof(MainWindow));
            OpenBookDetailsWindow = new RoutedCommand("OpenBookDetailsWindow", typeof(BookDetails));
            
        }
        public static RoutedCommand Undo { get; set; }
        public static RoutedCommand Redo { get; set; }
        public static RoutedCommand Exit { get; set; }
        public static RoutedCommand CloseBookDetails { get; set; }
        public static RoutedCommand OpenAddBookWindow { get; set; }
        public static RoutedCommand SaveItem { get; set; }
        public static RoutedCommand OpenBookDetailsWindow { get; set; }
        public static RoutedCommand AddFormat { get; set; }
        public static RoutedCommand SaveList { get; set; }
        public static RoutedCommand DeleteItem { get; set; }
        public static RoutedCommand EditItem { get; set; }
        public static RoutedCommand FilterSearch { get; set; }
        public static RoutedCommand SearchItem { get; set; }
    }
}
