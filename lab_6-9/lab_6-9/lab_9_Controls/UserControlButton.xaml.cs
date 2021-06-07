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

namespace lab_6_9.lab_9_Controls
{
    /// <summary>
    /// Логика взаимодействия для UserControlButton.xaml
    /// </summary>
    public partial class UserControlButton : UserControl
    {
        public UserControlButton()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler CloseButtonClick;

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CloseButtonClick != null) CloseButtonClick.Invoke(sender, e);
        }
    }
}
