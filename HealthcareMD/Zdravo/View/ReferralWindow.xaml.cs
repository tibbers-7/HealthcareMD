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
using HealthcareMD.ViewModel;


namespace HealthcareMD.DoctorView
{
    public partial class ReferralWindow : Window
    {
        private ReferralViewModel viewModel;
        public ReferralWindow(int doctorId)
        {
            viewModel = new ReferralViewModel(doctorId);
            this.DataContext = viewModel;
            InitializeComponent();
            
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (surgery_rb.IsChecked == false && appt_tb.IsChecked == false) MessageBox.Show("Niste uneli sve neophodne informacije!", "Greška"); 
            else if(viewModel.ScheduleReferral()==0) this.Close();

        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ChoosePatientShow();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
