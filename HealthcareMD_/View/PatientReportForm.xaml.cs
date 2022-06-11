using HealthcareMD_.ViewModel;
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

namespace HealthcareMD_.View
{
    /// <summary>
    /// Interaction logic for PatientReportForm.xaml
    /// </summary>
    public partial class PatientReportForm : Window
    {
        private ReportFormViewModel viewModel;
        public PatientReportForm(int patientId)
        {
            InitializeComponent();
            viewModel = new ReportFormViewModel(this,patientId);
            this.DataContext = viewModel;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Close();
        }

        private void GetReport_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Accept();
        }
    }
}
