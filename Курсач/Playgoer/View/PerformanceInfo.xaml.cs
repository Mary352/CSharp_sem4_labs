using Playgoer.Model.Repository_UoW;
using System.Linq;
using System.Windows;

namespace Playgoer.View
{
    /// <summary>
    /// Логика взаимодействия для PerformanceInfo.xaml
    /// </summary>
    public partial class PerformanceInfo : Window
    {
        private object selPrf;
        private string usrLgn;

        public PerformanceInfo(string userLogin, Performance selectedPerf)
        {
            InitializeComponent();
            selPrf = selectedPerf;
            usrLgn = userLogin;

            prfNameBlock.Text = selectedPerf.PName;
            prfGenreBlock.Text = selectedPerf.Genre;
            ageBlock.Text = selectedPerf.Age.ToString() + "+";
            durBlock.Text = selectedPerf.Duration.ToString() + " мин.";
            dateBlock.Text = selectedPerf.Date_time.Date.ToString("d");
            timeBlock.Text = selectedPerf.Date_time.TimeOfDay.ToString();

            using (UnitOfWork uow = new UnitOfWork())
            {
                Theater thr = uow.Theaters.GetConcreteObjectById(selectedPerf.TheaterId);
                thtrBlock.Text = thr.TName;
            }

            //Model1 db = new Model1();
            //Theater thr = db.Theaters.FirstOrDefault(th => th.Id == selectedPerf.TheaterId);
            //thtrBlock.Text = thr.TName;
        }

        // Купить билет
        private void btnTicketPay_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            PayorReserve payorReserve = new PayorReserve(usrLgn, (Performance)selPrf, null);
            payorReserve.Closed += (sender2, e2) => { this.Visibility = Visibility.Visible; };
            payorReserve.ShowDialog();
        }
    }
}
