using Controller;
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

namespace HealthcareMD_.DoctorWindows
{
    /// <summary>
    /// Interaction logic for PrescriptionWindow.xaml
    /// </summary>
    public partial class PrescriptionWindow : Window
    {
        private PrescriptionViewModel viewModel;
        private int chosenDrug;
        private int errorCode;

        public PrescriptionWindow(int id)
        {
            InitializeComponent();
            viewModel = new PrescriptionViewModel(this,id);
            DataContext = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            viewModel.ShowDrug();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Accept();
            
            
        }
    }
}
