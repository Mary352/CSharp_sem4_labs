using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
using System.Xml.Serialization;
using lab_6_9.Classes;
using lab_6_9.Views;

namespace lab_6_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ElectronicBook>));
        public ObservableCollection<ElectronicBook> ElectronicBooks { get; set; }
        public ObservableCollection<ElectronicBook> ChosenElectronicBooks { get; set; }
        private List<string> PB3 = new List<string>();
        private List<string> P740C = new List<string>();
        private List<string> AK8 = new List<string>();
        private string[] pb3 = { "DjVu", "DOC", "DOCX", "CHM", "ePub", "FB2", "HTML", "MOBI", "PDF", "RTF", "TXT" };
        private string[] p740c = { "DjVu", "DOC", "DOCX", "CHM", "ePub", "FB2", "HTML", "MOBI", "PDF", "RTF", "PRC", "TXT" };
        private string[] ak8 = { "AZW", "AZW3", "DOC", "DOCX", "HTML", "MOBI", "PDF", "TXT" };

        ElectronicBook deletedEBook, addedEBook;
        private string lastAction;

        object sndr;
        ExecutedRoutedEventArgs erea;

        bool searchingFlag = false;

        public MainWindow()
        {
            InitializeComponent();

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            ChosenElectronicBooks = new ObservableCollection<ElectronicBook>();

            PB3.AddRange(pb3);
            P740C.AddRange(p740c);
            AK8.AddRange(ak8);

            ElectronicBook eB1 = new ElectronicBook("Электронная книга PocketBook Basic 3 ", "PocketBook", "E-Ink Carta", "600x800", 
                "пластик", "белый", "/Images/PocketBook_Basic_3.jpeg", 208.93, 6, 3.5, 170.2, false, 1, PB3);
            ElectronicBook eB2 = new ElectronicBook("Электронная книга PocketBook 740 Color ", "PocketBook", "E-Ink New Kaleido", "1080x1440",
                "пластик", "серебристый", "/Images/PocketBook_740_Color.jpeg", 799, 7.8, 4.5, 225, true, 1, P740C);
            ElectronicBook eB3 = new ElectronicBook("Электронная книга Amazon Kindle (8-е поколение) ", "Amazon", "E-Ink Pearl", "600x800",
                "пластик", "черный", "/Images/Amazon_Kindle_(8_поколение).jpeg", 290, 7.8, 5, 161, true, 1, AK8);

            ElectronicBooks = new ObservableCollection<ElectronicBook>
            {
                eB1,
                eB2,
                eB3
            };

            eBooksList.ItemsSource = ElectronicBooks;
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            lastAction = "LanguageChanged"; 
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            lastAction = "ChangeLanguageClick";
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        // Поиск по строке
        private void SearchItem_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lastAction = "SearchItem_Executed";

            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("search item: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            if (searchBar.Text != "")
            {
                ChosenElectronicBooks.Clear();
                foreach (ElectronicBook elBook in ElectronicBooks)
                {
                    if (searchBar.Text.ToLower() == elBook.Name.ToLower() || (elBook.Name.ToLower()).Contains(searchBar.Text.ToLower()))
                    {
                        ChosenElectronicBooks.Add(elBook);
                    }
                }
                searchingFlag = true;
                eBooksList.ItemsSource = ChosenElectronicBooks;
            }
            else
                eBooksList.ItemsSource = ElectronicBooks;
        }

        // Сохранение в файл
        private void SaveList_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lastAction = "SaveList_Executed";
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("save list: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            using (FileStream fs = new FileStream("eBooksList.xml", FileMode.Create))
            {
                serializer.Serialize(fs, ElectronicBooks);
                MessageBox.Show("Сохранено");
            }
        }

        // Поиск по параметрам
        private void FilterSearch_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lastAction = "FilterSearch_Executed";
            double priceFrom, priceTo;

            ChosenElectronicBooks.Clear();
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("Filter Search: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            try
            {
                if (priceFromBox.Text != "")
                    priceFrom = Convert.ToDouble(priceFromBox.Text);
                else 
                    priceFrom = ElectronicBooks.Select(pr => pr.Price).Min();

                if (priceToBox.Text != "")
                    priceTo = Convert.ToDouble(priceToBox.Text);
                else
                    priceTo = ElectronicBooks.Select(pr => pr.Price).Max();

                // eBooksList.Items
                switch (backlightChBox.IsChecked)
                    {
                        case true:
                            foreach (ElectronicBook elBook in ElectronicBooks)
                            {
                            if (((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() == "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == true &
                                    elBook.ScreenResolution == ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else if (((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() == "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == true &
                                    elBook.ScreenTechnology == ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else if (((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() != "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == true &
                                    elBook.ScreenTechnology == ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() &
                                    elBook.ScreenResolution == ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == true)
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }

                            
                            }

                        break;
                        case false:
                            foreach (ElectronicBook elBook in ElectronicBooks)
                            {
                            if (((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() != "-----" & 
                                ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() == "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == false & 
                                    elBook.ScreenResolution == ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else if (((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() != "-----" & 
                                ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() == "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == false &
                                    elBook.ScreenTechnology == ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else if (((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() != "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == false &
                                    elBook.ScreenTechnology == ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() &
                                    elBook.ScreenResolution == ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.Backlight == false)
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            } 
                            }
                            break;
                        case null:
                            foreach (ElectronicBook elBook in ElectronicBooks)
                            {
                            if (((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() == "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.ScreenResolution == ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else if (((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() == "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.ScreenTechnology == ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else if (((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() != "-----" &
                                ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString() != "-----")
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo &
                                    elBook.ScreenTechnology == ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString() &
                                    elBook.ScreenResolution == ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString())
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                            else
                            {
                                if (elBook.Price >= priceFrom & elBook.Price <= priceTo)
                                {
                                    if (ChosenElectronicBooks.Contains(elBook))
                                    { }
                                    else
                                    {
                                        ChosenElectronicBooks.Add(elBook);

                                    }

                                }
                            }
                           
                            }
                        break;

                        default:
                            break;
                    }

                searchingFlag = true;
                eBooksList.ItemsSource = ChosenElectronicBooks;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            

        }
       
        // Выход
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lastAction = "Exit_Executed";
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.Close();
        }

        // Добавить
        private void OpenAddBookWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            sndr = sender;
            erea = e;
            lastAction = "OpenAddBookWindow_Executed";
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("Add new item: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            //this.Visibility = Visibility.Collapsed;
            AddBook addBook = new AddBook();
            //var result = ;
            try
            {
                if (addBook.ShowDialog() == true)
                {
                    ElectronicBooks.Add(addBook.eBook);
                    addedEBook = new ElectronicBook(addBook.eBook.Name, addBook.eBook.Manufactuter, addBook.eBook.ScreenTechnology,
                        addBook.eBook.ScreenResolution, addBook.eBook.BodyMater, addBook.eBook.Color, addBook.eBook.ImagePath,
                        addBook.eBook.Price, addBook.eBook.ScreenSize, addBook.eBook.Rating, addBook.eBook.Weight, addBook.eBook.Backlight,
                        addBook.eBook.RAM, addBook.eBook.TxtFormatsSupport);
                    
                    //MessageBox.Show();
                    //MessageBox.Show(addBook.eBook.Name);
                    //MessageBox.Show(ElectronicBooks.Last().Name);
                }                   
                
                //eBooksList.ItemsSource = ElectronicBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " OpenAddBookWindow_Executed");                
            }
            
        }

        // Подробнее
        private void OpenBookDetailsWindow_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lastAction = "OpenBookDetailsWindow_Executed";
            try
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("OpenBookDetailsWindow: " + DateTime.Now.ToShortDateString() + " " +
                    DateTime.Now.ToLongTimeString());
                    writer.Flush();
                }

                BookDetails bookDetails = new BookDetails((ElectronicBook)eBooksList.SelectedItem);
                bookDetails.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите товар, о котором хотите узнать подробнее");
            }
            
        }

        // Редактировать
        private void EditItem_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            try
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("EditItem: " + DateTime.Now.ToShortDateString() + " " +
                    DateTime.Now.ToLongTimeString());
                    writer.Flush();
                }

                AddBook addBook = new AddBook((ElectronicBook)eBooksList.SelectedItem);
                //var result = ;
                try
                {
                    if (addBook.ShowDialog() == true)
                    {
                        
                        ElectronicBooks.Remove((ElectronicBook)eBooksList.SelectedItem);
                        ElectronicBooks.Add(addBook.eBook);
                        lastAction = "EditItem_Executed";
                        //MessageBox.Show("add ok");
                        //MessageBox.Show(addBook.eBook.Name);
                        ///MessageBox.Show(ElectronicBooks.Last().Name);
                    }

                    //eBooksList.ItemsSource = ElectronicBooks;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите товар, информацию о котором нужно изменить");
            }
            
        }

        // Удалить
        private void DeleteItem_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            sndr = sender;
            erea = e;
            //MessageBox.Show(sender.ToString());
            //MessageBox.Show(e.ToString());
            using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("DeleteItem: " + DateTime.Now.ToShortDateString() + " " +
                    DateTime.Now.ToLongTimeString());
                    writer.Flush();
                }
                
                if (eBooksList.SelectedItem != null)
                {
                if (searchingFlag != true)
                {
                    deletedEBook = new ElectronicBook(((ElectronicBook)eBooksList.SelectedItem).Name, ((ElectronicBook)eBooksList.SelectedItem).Manufactuter,
                        ((ElectronicBook)eBooksList.SelectedItem).ScreenTechnology,
                        ((ElectronicBook)eBooksList.SelectedItem).ScreenResolution, ((ElectronicBook)eBooksList.SelectedItem).BodyMater,
                        ((ElectronicBook)eBooksList.SelectedItem).Color, ((ElectronicBook)eBooksList.SelectedItem).ImagePath,
                        ((ElectronicBook)eBooksList.SelectedItem).Price, ((ElectronicBook)eBooksList.SelectedItem).ScreenSize,
                        ((ElectronicBook)eBooksList.SelectedItem).Rating, ((ElectronicBook)eBooksList.SelectedItem).Weight, 
                        ((ElectronicBook)eBooksList.SelectedItem).Backlight,
                        ((ElectronicBook)eBooksList.SelectedItem).RAM, ((ElectronicBook)eBooksList.SelectedItem).TxtFormatsSupport);
                    ElectronicBooks.Remove((ElectronicBook)eBooksList.SelectedItem);
                    lastAction = "DeleteItem_Executed";

                }


                else
                {
                    lastAction = "DeleteItem_Executed";
                    deletedEBook = new ElectronicBook(((ElectronicBook)eBooksList.SelectedItem).Name, ((ElectronicBook)eBooksList.SelectedItem).Manufactuter,
                        ((ElectronicBook)eBooksList.SelectedItem).ScreenTechnology,
                        ((ElectronicBook)eBooksList.SelectedItem).ScreenResolution, ((ElectronicBook)eBooksList.SelectedItem).BodyMater,
                        ((ElectronicBook)eBooksList.SelectedItem).Color, ((ElectronicBook)eBooksList.SelectedItem).ImagePath,
                        ((ElectronicBook)eBooksList.SelectedItem).Price, ((ElectronicBook)eBooksList.SelectedItem).ScreenSize,
                        ((ElectronicBook)eBooksList.SelectedItem).Rating, ((ElectronicBook)eBooksList.SelectedItem).Weight,
                        ((ElectronicBook)eBooksList.SelectedItem).Backlight,
                        ((ElectronicBook)eBooksList.SelectedItem).RAM, ((ElectronicBook)eBooksList.SelectedItem).TxtFormatsSupport);
                    ElectronicBooks.Remove((ElectronicBook)eBooksList.SelectedItem);
                    ChosenElectronicBooks.Remove((ElectronicBook)eBooksList.SelectedItem);
                    lastAction = "DeleteItem_Executed";

                }

            }
                else
                {
                    MessageBox.Show("Выберите удаляемый товар");
                }

            //searchingFlag = false;
        }

        // Undo
        private void Undo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("Undo_Executed: " + DateTime.Now.ToShortDateString() + " " +
                    DateTime.Now.ToLongTimeString());
                    writer.Flush();
                }

                switch (lastAction)
                {
                    case "DeleteItem_Executed":
                        ElectronicBooks.Add(deletedEBook);
                        //eBooksList.ItemsSource = ElectronicBooks.ToString();
                        break;
                    case "OpenAddBookWindow_Executed":
                        ElectronicBooks.Remove(addedEBook);
                        break;
                    case "SearchItem_Executed":
                        eBooksList.ItemsSource = ElectronicBooks;
                        break;
                    default:
                        break;
                }
                // удаляемые добавить в массив и извлекать по номеру для последовательного добавления с пом undo,
                // для этого закомментировать lastAction = "undo";
                lastAction = "undo";
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите товар, о котором хотите узнать подробнее");
            }

        }

        // Redo
        private void Redo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            //MessageBox.Show(deletedEBook.Name);
            try
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("Redo_Executed: " + DateTime.Now.ToShortDateString() + " " +
                    DateTime.Now.ToLongTimeString());
                    writer.Flush();
                }

                switch (lastAction)
                {
                    case "DeleteItem_Executed":
                        DeleteItem_Executed(sndr, erea);
                        break;
                    case "OpenAddBookWindow_Executed":
                        OpenAddBookWindow_Executed(sndr, erea);
                        break;
                    default:
                        break;
                }

                //lastAction = "redo";
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите товар, о котором хотите узнать подробнее");
            }

        }

        private void GreenThemeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lastAction = "GreenThemeMenuItem_Click";
            setTheme("GreenStyle");
        }

        private void OptimisticMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lastAction = "OptimisticMenuItem_Click";
            setTheme("OptimisticStyle");
        }

        public void setTheme(string themeName)
        {
            //-------------Colors-------------
            // определяем путь к файлу ресурсов
            var uriColors = new Uri("/Style/" + themeName + "Colors.xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDictColors = Application.LoadComponent(uriColors) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDictColors);
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(eBooksList.SelectedIndex.ToString());
            if (eBooksList.SelectedIndex == -1) eBooksList.SelectedIndex = 0;
            else if (eBooksList.SelectedIndex != 0) eBooksList.SelectedIndex -= 1;
            eBooksList.ScrollIntoView(eBooksList.SelectedItem);
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (eBooksList.SelectedIndex == -1) eBooksList.SelectedIndex = 0;
            else if (eBooksList.SelectedIndex != eBooksList.Items.Count - 1) eBooksList.SelectedIndex += 1;
            eBooksList.ScrollIntoView(eBooksList.SelectedItem);
        }

        // MouseDown - поднимающееся событие (PreviewMouseDown - туннельное событие)
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            searchBar.Text = searchBar.Text + "sender: " + sender.ToString() + "\n";
            searchBar.Text = searchBar.Text + "source: " + e.Source.ToString() + "\n\n";
        }
    }    
}
