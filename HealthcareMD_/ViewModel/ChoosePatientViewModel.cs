using Model;
using System.Collections.ObjectModel;
using HealthcareMD_.Controller;
using HealthcareMD_.DoctorWindows;
using System.Windows;
using Tools;
using System;
using HealthcareMD_.DoctorView;
using System.Windows.Controls;

namespace HealthcareMD_.ViewModel
{
    internal class ChoosePatientViewModel : BindableBase 
    {
        private ObservableCollection<Patient> patients;
        public ObservableCollection<Patient> Patients { get { return patients; } set { patients = value; } }
        private PatientController patientController;
        public MyICommand AcceptCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public MyICommand CloseCommand { get; set; }
        private ChoosePatient callerWindow;

        public ChoosePatientViewModel(ChoosePatient callerWindow)
        {
            var app=Application.Current as App;
            patientController = app.patientController;
            patients = patientController.GetAll();
            this.callerWindow = callerWindow;
            AcceptCommand=new MyICommand(Accept);
            ShowCommand = new MyICommand(ShowPatient);
            CloseCommand=new MyICommand(Close);
        }

        internal void ShowPatient()
        {
            object item = callerWindow.patientTable.SelectedItem;
            PatientChart chart = new PatientChart(int.Parse((callerWindow.patientTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
            chart.Show();
        }

        internal void Accept()
        {
            object item = callerWindow.patientTable.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Niste odabrali pacijenta!", "Greška");
            }
            else
            {
                int chosenPatient = int.Parse((callerWindow.patientTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (callerWindow.caller.GetType().Name.Equals("NewAppointmentViewModel"))
                {
                    NewAppointmentViewModel _caller = (NewAppointmentViewModel)callerWindow.caller;
                    _caller.UpdatePatient(chosenPatient);
                }
                else
                {
                    ReferralViewModel _caller = (ReferralViewModel)callerWindow.caller;
                    _caller.UpdatePatient(chosenPatient);
                }
                callerWindow.Close();
            }
        }

        internal void Close()
        {
            callerWindow.Close();
        }
    }
}
