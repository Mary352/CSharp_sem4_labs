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
using System.Windows.Shapes;
using lab_6_9.Classes;
using lab_6_9.Views;

namespace lab_6_9.Views
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public ElectronicBook eBook;
        public ShortEBook shEBook = new ShortEBook();
        private List<string> txtFormats;

        public AddBook()
        {
            InitializeComponent();
            txtFormats = new List<string>();
        }

        public AddBook(ElectronicBook electronicBook)
        {
            InitializeComponent();
            txtFormats = new List<string>();

            pNameBox.Text = electronicBook.Name; 
            manufBox.Text = electronicBook.Manufactuter; 
            colorBox.Text = electronicBook.Color; 
            imagePathBox.Text = electronicBook.ImagePath; 
            priceBox.Text = electronicBook.Price.ToString(); 
            screenSizeBox.Text = electronicBook.ScreenSize.ToString(); 
            weightBox.Text = electronicBook.Weight.ToString(); 
            rateBox.Text = electronicBook.Rating.ToString();
            if (electronicBook.Backlight)
            {
                backlightChBox.IsChecked = true;
            }
            //backlightChBox = electronicBook.Backlight.ToString(); 
            ramBox.Text = electronicBook.RAM.ToString();
            MessageBox.Show("требуется заново добавить текстовые форматы");
        }

        private void AddFormat_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("add format: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            if (txtFormatsBox.Text != "")
            {
                txtFormats.Add(txtFormatsBox.Text);
                txtFormatsBox.Clear();
            }
        }

        private void SaveItem_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("add new and save: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            if (pNameBox.Text != "" & manufBox.Text != "" & colorBox.Text != "" & imagePathBox.Text != "" & priceBox.Text != ""
                & screenSizeBox.Text != "" & weightBox.Text != "" & rateBox.Text != "" & backlightChBox != null & ramBox.Text != "" & txtFormats != null)
            {
                try
                {
                    //ComboBoxItem selectedItem = (ComboBoxItem)comboMater.SelectedItem;
                    //string selCity = selectedItem.Content.ToString();
                    //MessageBox
                    eBook = new ElectronicBook(pNameBox.Text, manufBox.Text, ((ComboBoxItem)comboScreenTech.SelectedItem).Content.ToString(), 
                        ((ComboBoxItem)comboScreenResol.SelectedItem).Content.ToString(), ((ComboBoxItem)comboMater.SelectedItem).Content.ToString(),
                        colorBox.Text, imagePathBox.Text, Convert.ToDouble(priceBox.Text), Convert.ToDouble(screenSizeBox.Text),
                    Convert.ToDouble(rateBox.Text), Convert.ToDouble(weightBox.Text), (bool)backlightChBox.IsChecked, Convert.ToInt32(ramBox.Text), txtFormats);
                    //MessageBox.Show(eBook.ToString());
                    //MessageBox.Show(eBook.Name);
                    //MessageBox.Show(eBook.Weight.ToString());
                    shEBook.Name2 = pNameBox.Text;
                    shEBook.Weight2 = Convert.ToDouble(weightBox.Text);
                    MessageBox.Show("Проверка. Если введённое значение совпадает с " + shEBook.Weight2.ToString() + 
                       ", тогда ОК, в противном случае нужно установить значение меньше выведенного для сравнения" +
                        "\n Имя объекта: " + shEBook.Name2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " SaveItem_Executed");
                }
                
                this.DialogResult = true;
                this.Close();
            }
            else
                MessageBox.Show("Заполните все поля");
            
        }

        
    }
}
