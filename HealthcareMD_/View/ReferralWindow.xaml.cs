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
using HealthcareMD_.ViewModel;


namespace HealthcareMD_.DoctorView
{
    public partial class ReferralWindow : Window
    {
        private ReferralViewModel viewModel;
        public ReferralWindow(int doctorId)
        {
            viewModel = new ReferralViewModel(this,doctorId);
            this.DataContext = viewModel;
            InitializeComponent();
            
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ScheduleReferral();

        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ChoosePatientShow();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Cancel();
        }
    }


}
