using System.Windows;
using HealthcareMD_.ViewModel;

namespace HealthcareMD_.DoctorView
{
    /// <summary>
    /// Interaction logic for DrugReportWindow.xaml
    /// </summary>
    public partial class DrugReportWindow : Window
    {
        private DrugReportViewModel viewModel;
        public DoctorHomeViewModel callerWindow;
        private int errorCode;

        public DrugReportWindow(DoctorHomeViewModel callerWindow,int drugId)
        {
            viewModel = new DrugReportViewModel(this,drugId);
            this.callerWindow = callerWindow;
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateDrugReport();
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Close();
        }
    }
}
