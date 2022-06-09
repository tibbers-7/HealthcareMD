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
using HealthcareMD.DoctorWindows;
using HealthcareMD.ViewModel;

namespace HealthcareMD.DoctorView
{
    public partial class ChoosePatient : Window
    {
        private ChoosePatientViewModel viewModel=new ChoosePatientViewModel();
        internal int chosenPatient;
        private object caller;
        public ChoosePatient(object caller)
        {
            this.caller = caller;

            InitializeComponent();
            this.DataContext = viewModel;
            
            
        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = patientTable.SelectedItem;
            viewModel.ShowPatient(int.Parse((patientTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            object item = patientTable.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Niste odabrali pacijenta!", "Greška");
            }
            else
            {
                chosenPatient = int.Parse((patientTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (caller.GetType().Name.Equals("NewAppointmentViewModel"))
                {
                    NewAppointmentViewModel _caller = (NewAppointmentViewModel)caller;
                    _caller.UpdatePatient(chosenPatient);
                }
                else
                {
                    ReferralViewModel _caller = (ReferralViewModel)caller;
                    _caller.UpdatePatient(chosenPatient);
                }
                this.Close();
            }
        }
    }
}
