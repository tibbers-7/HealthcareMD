using System.Windows;
using System.Windows.Controls;
using HealthcareMD.ViewModel;

namespace HealthcareMD.DoctorWindows
{
    public partial class PatientChart : Window
    {
        private PatientChartViewModel viewModel;

        public PatientChart(int patientId)
        {
            viewModel = new PatientChartViewModel(patientId);
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
            this.Close();
        }


        private void ReportRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = reportTable.SelectedItem;
            viewModel.ShowReport(int.Parse((reportTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        private void DrugRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = prescTable.SelectedItem;
            viewModel.ShowDrug(int.Parse((prescTable.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text));
        }

    }
}
