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
    /// <summary>
    /// Interaction logic for VacationWindow.xaml
    /// </summary>
    public partial class VacationWindow : Window
    {
        private VacationViewModel viewModel;
        public VacationWindow(int vacationId)
        {
            InitializeComponent();
            viewModel = new VacationViewModel(vacationId);
            DataContext = viewModel;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
