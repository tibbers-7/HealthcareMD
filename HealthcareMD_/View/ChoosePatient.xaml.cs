using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using HealthcareMD_.DoctorWindows;
using HealthcareMD_.ViewModel;

namespace HealthcareMD_.DoctorView
{
    public partial class ChoosePatient : Window
    {
        private ChoosePatientViewModel viewModel;
        internal int chosenPatient;
        internal object caller;
        public ChoosePatient(object caller)
        {
            this.caller = caller;
            viewModel = new ChoosePatientViewModel(this);
            InitializeComponent();
            this.DataContext = viewModel;
            
            
        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            viewModel.ShowPatient();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Accept();
        }
    }
}
