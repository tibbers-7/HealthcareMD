using System.Windows;
using HealthcareMD.ViewModel;

namespace HealthcareMD.DoctorView
{
    /// <summary>
    /// Interaction logic for DrugReportWindow.xaml
    /// </summary>
    public partial class DrugReportWindow : Window
    {
        private DrugReportViewModel viewModel;
        private DoctorHomeViewModel callerWindow;
        private int errorCode;

        public DrugReportWindow(DoctorHomeViewModel callerWindow,int drugId)
        {
            viewModel = new DrugReportViewModel(drugId);
            this.callerWindow = callerWindow;
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (reason_tb.Text.Equals(""))
            {
                MessageBox.Show("Niste uneli sve potrebne podatke!", "Greška");
            }
            else
            {
                errorCode = viewModel.CreateDrugReport();
                if (errorCode == 0)
                {
                    callerWindow.RefreshDrugs();
                    this.Close();
                }
            }
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
