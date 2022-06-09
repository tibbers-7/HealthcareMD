using Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HealthcareMD.Controller;
using HealthcareMD.DoctorView;
using HealthcareMD.DoctorWindows;

namespace HealthcareMD.ViewModel
{
    internal class ReferralViewModel: INotifyPropertyChanged
    {
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }
        private ObservableCollection<string> specializations;
        public ObservableCollection<string> Specializations { get { return specializations; } set { specializations = value; } }
        private bool surgery;
        public bool Surgery { get { return surgery; } set { surgery = value;} }
        private bool appt;
        public bool Appt { get { return appt; } set { appt = value; } }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }
        private string doctorSpecialization;
        public string DoctorSpecialization { get { return doctorSpecialization; } set { doctorSpecialization = value; } }
        private int doctorId;
        private string currentDoctor;
        public string CurrentDoctor { get { return currentDoctor; } set { currentDoctor = value; } }
        
        private AppointmentController apptController;
        private int errorCode;

        public ReferralViewModel(int doctorId)
        {
            this.doctorId=doctorId;
            var app = Application.Current as App;
            apptController = app.appointmentController;
            specializations = apptController.GetAllSpetializations();
            currentDoctor = apptController.GetDoctorInfo(doctorId);

        }

        internal void ChoosePatientShow()
        {
            ChoosePatient choosePatient = new ChoosePatient(this);
            choosePatient.Show();
        }

        internal int ScheduleReferral()
        {
            errorCode= apptController.CreateReferral(patientId,doctorId, doctorSpecialization, appt,emergency);
            switch (errorCode)
            {
                case 0:
                    MessageBox.Show("Uspešno kreiran uput", "Obaveštenje");
                    break;
                case 1:
                    MessageBox.Show("Pacijent ne postoji!", "Greška");
                    break;
                case 2:
                    MessageBox.Show("Trenutno ne postoji lekar te specijalizacije u sistemu!", "Greška");
                    break;
                case 3:
                    MessageBox.Show("Niste uneli sve neophodne informacije!", "Greška");
                    break;
            }
            return errorCode;

        }

        internal void ShowChart()
        {
            PatientChart chartWindow = new PatientChart(patientId);
            chartWindow.Show();
        }

        internal void UpdatePatient(int chosenPatient)
        {
            patientId = chosenPatient;
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
