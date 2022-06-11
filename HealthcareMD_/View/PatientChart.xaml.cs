using System.Windows;
using System.Windows.Controls;
using HealthcareMD_.ViewModel;
using Model;

namespace HealthcareMD_.DoctorWindows
{
    public partial class PatientChart : Window
    {
        private PatientChartViewModel viewModel;

        public PatientChart(int patientId)
        {
            viewModel = new PatientChartViewModel(this,patientId);
            this.DataContext = viewModel;
            InitializeComponent();
            InitFields();
        }

        private void InitFields()
        {
            if (viewModel.Gender == 'm')
            {
                male.IsChecked = true;
                female.IsEnabled = false;
            }
            else
            {
                female.IsChecked = true;
                male.IsEnabled = false;
            }
            switch (viewModel.MarriageStatus)
            {
                case 'm':
                    married.IsChecked = true;
                    widow.IsEnabled = false;
                    divorced.IsEnabled = false;
                    single.IsEnabled = false;
                    break;
                case 'w':
                    widow.IsChecked = true;
                    married.IsEnabled = false;
                    divorced.IsEnabled = false;
                    single.IsEnabled = false;
                    break;
                case 'd':
                    divorced.IsChecked = true;
                    married.IsEnabled = false;
                    widow.IsEnabled = false;
                    single.IsEnabled = false;
                    break;
                default:
                    single.IsChecked = true;
                    married.IsEnabled = false;
                    widow.IsEnabled = false;
                    divorced.IsEnabled = false;
                    break;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Accept();
        }

        private void Report_DoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            Report report = (Report)item.Content;
            viewModel.ShowReport(report.Id);
        }

        private void Prescription_DoubleClick(object sender, RoutedEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            Prescription prescription = (Prescription)item.Content;
            viewModel.ShowDrug(prescription.DrugId);
        }

    }
}
