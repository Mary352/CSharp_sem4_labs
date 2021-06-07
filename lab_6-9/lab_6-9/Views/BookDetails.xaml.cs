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
using System.Windows.Resources;
using System.Windows.Shapes;
using lab_6_9.Classes;
using lab_6_9.Views;

namespace lab_6_9.Views
{
    /// <summary>
    /// Логика взаимодействия для BookDetails.xaml
    /// </summary>
    public partial class BookDetails : Window
    {
        private string txtFormats;

        public BookDetails(ElectronicBook eBook)
        {
            InitializeComponent();
            txtFormats = "";
            //this.Cursor = Cursors.None;
            //StreamResourceInfo sri = Application.GetResourceStream(
            //new Uri("/Settings/quill.cur", UriKind.Relative));
            //Cursor customCursor = new Cursor(sri.Stream);
            //this.Cursor = customCursor;

            priceBox.Text = eBook.Price.ToString() + " руб.";
            image.Source = new BitmapImage(new Uri(eBook.ImagePath, UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
            pNameBox.Text = eBook.Name;
            manufBox.Text = eBook.Manufactuter;
            screenTechBox.Text = eBook.ScreenTechnology;
            screenResolBox.Text = eBook.ScreenResolution;
            materBox.Text = eBook.BodyMater;
            colorBox.Text = eBook.Color;
            screenSizeBox.Text = eBook.ScreenSize.ToString() + "\"";
            rateBox.Text = eBook.Rating.ToString();
            if (eBook.Backlight == true)
                backlightBox.Text = "есть";
            else
                backlightBox.Text = "нет";
            ramBox.Text = eBook.RAM.ToString();
            foreach (string txtFormat in eBook.TxtFormatsSupport)
            {
                if (txtFormat == eBook.TxtFormatsSupport.Last())
                    txtFormats += txtFormat;
                else
                    txtFormats += txtFormat + ", ";

            }
            txtFormatsBox.Text = txtFormats;
            weightBox.Text = eBook.Weight.ToString() + " г";

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void CloseBookDetails_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("close details: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
