using System.Windows;
using HealthcareMD_.ViewModel;

namespace HealthcareMD_
{
    public partial class NewAppointment: Window { 
        private NewAppointmentViewModel viewModel;
        private DoctorHomeViewModel callerWindow;
        private int apptId;
        

        public NewAppointment(DoctorHomeViewModel callerWindow, int apptId,int doctorId,bool isEditable)
        {
            
            InitializeComponent();
            viewModel = new NewAppointmentViewModel(apptId, doctorId);
            if (apptId == 0)
            {
                patientLabel.Content = "Izaberi pacijenta";
                viewModel.operationMessage = "dodat";
            }
            else patientId_tb.IsReadOnly = true;
            
            if (!isEditable)
            {
                patientId_tb.IsReadOnly = true;
                date_tb.IsReadOnly=true;
                hour_tb.IsReadOnly = true;
                minutes_tb.IsReadOnly = true;
                rooms_cb.IsReadOnly = true;
                duration_tb.IsReadOnly = true;
            }

            this.callerWindow = callerWindow;
            this.apptId = apptId;
            
            DataContext = viewModel;   
        }
        
        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (rooms_cb.SelectedIndex == -1 | duration_tb.Text.Equals("0") | date_tb.Text.Equals("")) MessageBox.Show("Nisu unete svi potrebne informacije.", "Greška");
            else if (viewModel.AppointmentManagement() == 0)
            {
                callerWindow.RefreshAppointments();
                this.Close();
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            if (apptId == 0) viewModel.ChoosePatient();
            else viewModel.ShowChart(apptId);
        }
    }
}
