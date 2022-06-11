using System.Windows;
using HealthcareMD_.ViewModel;

namespace HealthcareMD_
{
    public partial class NewAppointment: Window { 
        private NewAppointmentViewModel viewModel;
        internal DoctorHomeViewModel callerWindow;
        private int apptId;
        

        public NewAppointment(DoctorHomeViewModel callerWindow, int apptId,int doctorId,bool isEditable)
        {
            
            InitializeComponent();
            viewModel = new NewAppointmentViewModel(this,apptId, doctorId);
            if (apptId == 0)
            {
                patientLabel.Content = "Izaberi pacijenta [P]";
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
            viewModel.AppointmentManagement();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Close();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PatientClick();
        }
    }
}
