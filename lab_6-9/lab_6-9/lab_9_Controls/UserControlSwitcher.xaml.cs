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

namespace lab_6_9.Controls
{
    /// <summary>
    /// Логика взаимодействия для UserControlSwitcher.xaml
    /// </summary>
    public partial class UserControlSwitcher : UserControl
    {
        public UserControlSwitcher()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler PreviousClick;
        public event RoutedEventHandler NextClick;

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if (PreviousClick != null) PreviousClick.Invoke(sender, e);            
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            NextClick?.Invoke(sender, e);
        }
    }
}
