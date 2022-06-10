using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using HealthcareMD.Controller;
using HealthcareMD.DoctorView;
using HealthcareMD.DoctorWindows;
using HealthcareMD.View;

namespace HealthcareMD.ViewModel
{
    public class DoctorHomeViewModel : INotifyPropertyChanged
    {
        AppointmentController appointmentController;
        VacationController vacationController;
        DrugController drugController;
        PatientController patientController;
        private ObservableCollection<Appointment> upcomingAppointments;
        private ObservableCollection<Appointment> passedAppointments;
        private ObservableCollection<Appointment> todaysAppointments;
        private ObservableCollection<VacationString> vacations;
        private ObservableCollection<VacationString> upcomingVacations;
        private ObservableCollection<Drug> drugs;
        private ObservableCollection<Patient> patients;
        private int doctorId;
        private string date;
        public string Date { get { return date; } set { date = value; } }
        private int hours;
        public int Hours { get { return hours; } set { hours = value; } }
        private int minutes;
        public int Minutes { get { return minutes; } set { minutes = value; } }

        private string startDate;
        public string StartDate { get { return startDate; } set { startDate = value; } }

        private string endDate;
        public string EndDate { get { return endDate; } set { endDate = value; } }

        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        private bool emergency;
        private int errorCode;

        public bool Emergency { get { return emergency; } set { emergency = value; } }
        private string doctorName;
        public string DoctorName { get { return doctorName; } set { doctorName = value; } }
        private string doctorProfession;
        public string DoctorProfession { get { return doctorProfession; } set { doctorProfession = value; } }
        


        public DoctorHomeViewModel(int doctorId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            drugController = app.drugController;
            vacationController=app.vacationController;
            patientController=app.patientController;
            this.doctorId=doctorId;
            upcomingAppointments = new ObservableCollection<Appointment>(appointmentController.GetUpcomingAppointmentsForDoctor(doctorId));
            passedAppointments = new ObservableCollection<Appointment>(appointmentController.GetPassedAppointmentsForDoctor(doctorId));
            todaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments(doctorId));
            upcomingVacations = new ObservableCollection<VacationString>(vacationController.GetUpcomingVacations(doctorId));
            drugs=new ObservableCollection<Drug>(drugController.GetValidDrugs());
            vacations= new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
            patients = new ObservableCollection<Patient>(patientController.GetAll());
            doctorName = appointmentController.GetDoctorName(doctorId);
            doctorProfession = appointmentController.GetDoctorProfession(doctorId);
        }

        internal void VacationShow(int vacationId)
        {
            VacationWindow vacationWindow=new VacationWindow(vacationId);
            vacationWindow.Show();
        }

        internal void PatientShow(int patientId)
        {
            PatientChart patientChart=new PatientChart(patientId);
            patientChart.Show();
        }

        internal void DrugShow(int drugId)
        {
            DrugWindow drugWindow = new DrugWindow(this, drugId);
            drugWindow.Show();
        }
        internal void ShowReferral()
        {
            ReferralWindow referralWindow = new ReferralWindow(doctorId);
            referralWindow.Show();
        }

        internal void AppointmentShow(int id)
        {
            NewAppointment updateAppointment = new NewAppointment(this, id, doctorId,false);
            updateAppointment.Show();
        }

        public void RefreshAppointments()
        {
            UpcomingAppointments = new ObservableCollection<Appointment>(appointmentController.GetPassedAppointmentsForDoctor(doctorId));
            PassedAppointments = new ObservableCollection<Appointment>(appointmentController.GetPassedAppointmentsForDoctor(doctorId));
            
        }

        internal void ReportDrug(int drugId)
        {
            DrugReportWindow drugReportWindow = new DrugReportWindow(this, drugId);
            drugReportWindow.Show();
        }

        public void RefreshDrugs()
        {
            Drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
        }

        public void RefreshVacations()
        {
            Vacations = new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
        }
        internal void PrescriptionShow(int id)
        {
            PrescriptionWindow prescriptionWindow = new PrescriptionWindow(id);
            prescriptionWindow.Show();
        }

        public void NewAppointment()
        {
            NewAppointment newAppointment = new NewAppointment(this,0,doctorId,true);
            newAppointment.Show();
        }

        internal void PatientReportForm(int patientId)
        {
            PatientReportForm patientReportForm = new PatientReportForm(patientId);
            patientReportForm.Show();
        }

        internal void UpdateAppointment(int id)
        {
            NewAppointment updateAppointment = new NewAppointment(this, id, doctorId,true);
            updateAppointment.Show();
        }

        internal int ScheduleVacation(bool emergency)
        {
            int error=vacationController.ScheduleVacation(doctorId,startDate,endDate,reason, emergency);
            RefreshVacations();
            switch (error)
            {
                case 0:
                    MessageBox.Show("Zahtev za slobodne dane je uspešno poslat.", "Obaveštenje");
                    break;
                case 1:
                    MessageBox.Show("Navedeni datum je prošao!", "Greška");
                    break;
                case 2:
                    MessageBox.Show("Krajnji datum je pre početnog!", "Greška");
                    break;
                case 3:
                    MessageBox.Show("Slobodni dani se zakazuju minimalno 48h ranije.", "Greška");
                    break;
                case 4:
                    MessageBox.Show("Zakazivanje slobodnih dana u tom periodu nije moguće zbog preklapanja.", "Greška");
                    break;
                case -1:
                    MessageBox.Show("Neuspešan upis u datoteku!", "Interna greška");
                    break;
            }
            return error;
        }

        

        internal void ReportShow(int id)
        {
            ReportWindow reportWindow = new ReportWindow(id, 0, 0, null);
            reportWindow.Show();
        }

        internal void DeleteAppt(int id)
        {
            errorCode = appointmentController.DeleteAppointment(id);
            switch (errorCode)
            {
                case 0:
                    MessageBox.Show("Uspešno obrisan pregled", "Obaveštenje");
                    RefreshAppointments();
                    break;
                case 1:
                    MessageBox.Show("ID pregleda ne postoji u bazi!", "Interna greška");
                    break;
                case 2:
                    MessageBox.Show("ID pacijenta ne postoji u bazi!", "Interna greška");
                    break;
                case -1:
                    MessageBox.Show("Neuspešan upis u datoteku!", "Interna greška");
                    break;
            }
            
        }


        public ObservableCollection<Appointment> UpcomingAppointments
        {
            get
            {
                return upcomingAppointments;
            }
            set
            {
                if (upcomingAppointments == value)
                    return;
                upcomingAppointments = new ObservableCollection<Appointment>(appointmentController.GetUpcomingAppointmentsForDoctor(doctorId));
                NotifyPropertyChanged("UpcomingAppointments");
            }
        }

        public ObservableCollection<Appointment> PassedAppointments
        {
            get
            {
                return passedAppointments;
            }
            set
            {
                if (passedAppointments == value)
                    return;
                passedAppointments = new ObservableCollection<Appointment>(appointmentController.GetPassedAppointmentsForDoctor(doctorId));
                NotifyPropertyChanged("PassedAppointments");
            }
        }

        public ObservableCollection<Appointment> TodaysAppointments
        {
            get
            {
                return todaysAppointments;
            }
            set
            {
                if (todaysAppointments == value)
                    return;
                todaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments(doctorId));
                NotifyPropertyChanged("TodaysAppointments");
            }
        }

        public ObservableCollection<VacationString> Vacations
        {
            get
            {
                return vacations;
            }
            set
            {
                if (vacations == value)
                    return;
                vacations = new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
                NotifyPropertyChanged("Vacations");
            }
        }

        public ObservableCollection<VacationString> UpcomingVacations
        {
            get
            {
                return upcomingVacations;
            }
            set
            {
                if (upcomingVacations == value)
                    return;
                upcomingVacations = new ObservableCollection<VacationString>(vacationController.GetUpcomingVacations(doctorId));
                NotifyPropertyChanged("UpcomingVacations");
            }
        }

        public ObservableCollection<Patient> Patients
        {
            get
            {
                return patients;
            }
            set
            {
                if (patients == value)
                    return;
                patients = new ObservableCollection<Patient>(patientController.GetAll());
                NotifyPropertyChanged("Patients");
            }
        }

        public ObservableCollection<Drug> Drugs
        {
            get
            {
                return drugs;
            }
            set
            {
                if (drugs == value)
                    return;
                drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
                NotifyPropertyChanged("Drugs");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
