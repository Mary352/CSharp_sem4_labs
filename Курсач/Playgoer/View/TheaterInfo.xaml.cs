using System.Windows;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для TheaterInfo.xaml
    /// </summary>
    public partial class TheaterInfo : Window
    {
        public TheaterInfo(Theater selectedThr)
        {
            InitializeComponent();

            thtrnameBlock.Text = selectedThr.TName;
            tcityBlock.Text = selectedThr.City;
            tadressBlock.Text = selectedThr.Address;
            tphoneBlock.Text = selectedThr.Phone;
        }
    }
}
