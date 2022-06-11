using HealthcareMD_.Controller;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using HealthcareMD_.DoctorView;
using HealthcareMD_.DoctorWindows;
using System.Windows;
using Controller;

namespace HealthcareMD_.ViewModel
{
    public class NewAppointmentViewModel: INotifyPropertyChanged
    {

        private int patientId;
        public int PatientId {get{return patientId;} set{patientId = value;}}

        private int roomId;
        public int RoomId { get { return roomId; } set { roomId = value; } }

        private int hour;
        public int Hour { get { return hour; } set { hour = value; } }
        private int minutes;
        public int Minutes { get { return minutes; } set { minutes = value; } }
        private int day;
        public int Day { get { return day; } set { day = value; } }
        private int month;
        public int Month { get { return month; } set { month = value; } }
        private int year;
        public int Year { get { return year; } set { year = value; } }
        private int duration;
        public int Duration { get { return duration; } set { duration = value; } }
        private string date;
        public string Date { get { return date; } set { date = value; } }

        private RoomController roomController;
        private int doctorId;
        private ObservableCollection<int> rooms;
        public ObservableCollection<int> Rooms
        {
            get {
                rooms = roomController.getAllIds(); 
                return rooms; }
            set { rooms = roomController.getAllIds(); }
        }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }

        private Appointment appt;
        private int id;
        internal string operationMessage = "izmenjen";

        private AppointmentController apptController;
        private PatientController patientController;
        private int errorCode;

        public NewAppointmentViewModel(int id,int doctorId)
        {
            var app = Application.Current as App;
            apptController = app.appointmentController;
            roomController = app.roomController;
            patientController = app.patientController;
            this.id = id;
            this.doctorId = doctorId;

            if (id != 0) InitFields();
            
        }

        private void InitFields()
        {
            appt = apptController.GetById(id);
            patientId = appt.Patient;
            roomId = appt.Room;
            duration = appt.Duration;
            date = appt.Date.ToString("dd/MM/yyyy");


            Regex regexObj = new Regex("(\\d+):(\\d{2})");
            Match matchResult = regexObj.Match(appt.Time.ToString());
            hour = int.Parse(matchResult.Groups[1].Value);
            minutes = int.Parse(matchResult.Groups[2].Value);
            emergency = appt.Emergency;
        }

        internal void ShowChart(int id)
        {
            Appointment appt= apptController.GetById(id);
            Patient patient=patientController.GetById(appt.Patient);
            if (patient == null)
            {
                MessageBox.Show("Pacijent ne postoji u bazi!", "Interna greška");
                return;
            }
            PatientChart chartWindow = new PatientChart(appt.Patient);
            chartWindow.Show();
        }

        internal void ChoosePatient()
        {
            ChoosePatient patientWindow = new ChoosePatient(this);
            patientWindow.Show();
        }

        public int AppointmentManagement()
        { 
            
            if (id == 0) errorCode=apptController.CreateAppointment(patientId,doctorId, roomId, hour, minutes, duration,date,emergency);
            else errorCode= apptController.UpdateAppointment(id, patientId,doctorId, roomId, hour, minutes, duration,date,emergency);
            switch (errorCode)
            {
                case 0:
                    
                    string message = "Uspešno " + operationMessage + " pregled.";
                    MessageBox.Show(message, "Obaveštenje");
                    break;
                case 1:
                    MessageBox.Show("Pacijent sa tim JMBG ne postoji.", "Greška");
                    break;
                case 2:
                    MessageBox.Show("Vreme koje ste odabrali za zakazivanje termina je prošlo.", "Greška");
                    break;
            }
            return errorCode;

        }

        public void UpdatePatient(int patientId)
        {
            this.patientId=patientId;
            NotifyPropertyChanged("PatientId");
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
      
}

    

