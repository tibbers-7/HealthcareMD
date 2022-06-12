using Controller;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using HealthcareMD_.Controller;
using HealthcareMD_.DoctorView;
using HealthcareMD_.DoctorWindows;
using HealthcareMD_.View;
using System.Collections.Generic;
using HealthcareMD_.Model;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Windows.Media;
using Tools;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace HealthcareMD_.ViewModel
{
    public class DoctorHomeViewModel : BindableBase, INotifyPropertyChanged
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
        private DoctorHome doctorHome;
        
        
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

        private List<AppointmentData> data;
        public object selectedAppt;
        public object selectedVacation;
        

        private List<BarItem> barItems;
        private BarSeries barSeries;
        private string[] categorySource;
        private CategoryAxis categoryAxis;


        public DoctorHomeViewModel(DoctorHome doctorHome,int doctorId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            drugController = app.drugController;
            vacationController=app.vacationController;
            patientController=app.patientController;
            this.doctorId=doctorId;
            this.doctorHome=doctorHome;

            InitFields();
            InitOxyChart();
            InitInteractivity();
            

        }

        private void InitFields()
        {
            upcomingAppointments = new ObservableCollection<Appointment>(appointmentController.GetUpcomingAppointmentsForDoctor(doctorId));
            passedAppointments = new ObservableCollection<Appointment>(appointmentController.GetPassedAppointmentsForDoctor(doctorId));
            todaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments(doctorId));
            upcomingVacations = new ObservableCollection<VacationString>(vacationController.GetUpcomingVacations(doctorId));
            drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
            vacations = new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
            patients = new ObservableCollection<Patient>(patientController.GetAll());
            doctorName = appointmentController.GetDoctorName(doctorId);
            doctorProfession = appointmentController.GetDoctorProfession(doctorId);
            data = appointmentController.GetAppointmentData(doctorId);
        }

        private void InitOxyChart()
        {
            model = new PlotModel { Title = "Učestalost zakazivanja pregleda" };
            GetDataForChart();
            
            model.Series.Add(barSeries);
            model.Axes.Add(categoryAxis);
            model.TitleColor = OxyColor.FromRgb(76, 126, 130);
            model.TextColor= OxyColor.FromRgb(76, 126, 130); 
        }

        internal void Logout()
        {
            MainWindow m = new MainWindow();
            m.Show();

            doctorHome.Close();
        }

        private void InitInteractivity()
        {
            NewAppointmentCommand = new MyICommand(NewAppointment);
            ReferralCommand = new MyICommand(ShowReferral);
            ShowCommand = new MyICommand(Show);
            UpdateCommand = new MyICommand(UpdateAppointment);
            DeleteCommand = new MyICommand(DeleteAppt);
            ReportCommand = new MyICommand(Report);
            PrescCommand = new MyICommand(PrescriptionShow);
            DrugReportCommand = new MyICommand(ReportDrug);
            MainTabCommand=new MyICommand(MainTabShow);
            ApptTabCommand = new MyICommand(ApptTabShow);
            PatientsTabCommand = new MyICommand(PatientsTabShow);
            DrugsTabCommand = new MyICommand(DrugsTabShow);
            VacationTabCommand = new MyICommand(VacationTabShow);
            ScheduleVacationCommand=new MyICommand(ScheduleVacation);

        }

        private void Report()
        {
            if (doctorHome.PassedTable.SelectedItem != null) ReportShow();
            else if (doctorHome.PatientTable.SelectedItem != null) PatientReportForm();
            else MessageBox.Show("Niste odabrali pregled/pacijenta!", "Obaveštenje");

        }
        private void GetDataForChart()
        {
            barItems = new List<BarItem>();
            categorySource = new string[data.Count];
            int i = 0;
            foreach (AppointmentData data_ in data)
            {
                barItems.Add(new BarItem { Value = data_.AppointmentCount });
                categorySource[i++] = data_.DaySerbian;
            }

            barSeries = new BarSeries
            {
                ItemsSource = barItems,
                LabelPlacement = LabelPlacement.Inside,

            };
            //#FF99E1D9
            barSeries.FillColor= OxyColor.FromRgb(112, 171, 175);

            categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "DaysAxis",
                ItemsSource = categorySource
            };
        }

        private void Show()
        {
            if (doctorHome.PassedTable.SelectedItem != null) AppointmentShow(int.Parse((doctorHome.PassedTable.SelectedCells[0].Column.GetCellContent(doctorHome.PassedTable.SelectedItem) as TextBlock).Text));
            else if (doctorHome.UpcomingTable.SelectedItem != null) AppointmentShow(int.Parse((doctorHome.UpcomingTable.SelectedCells[0].Column.GetCellContent(doctorHome.UpcomingTable.SelectedItem) as TextBlock).Text));
            else if (doctorHome.VacationTable.SelectedItem != null) VacationShow(int.Parse((doctorHome.VacationTable.SelectedCells[0].Column.GetCellContent(doctorHome.VacationTable.SelectedItem) as TextBlock).Text));
            else if (doctorHome.DrugsTable.SelectedItem != null) DrugShow(int.Parse((doctorHome.DrugsTable.SelectedCells[0].Column.GetCellContent(doctorHome.DrugsTable.SelectedItem) as TextBlock).Text));
            else if (doctorHome.PatientTable.SelectedItem != null) PatientShow(int.Parse((doctorHome.PatientTable.SelectedCells[0].Column.GetCellContent(doctorHome.PatientTable.SelectedItem) as TextBlock).Text));
            else if (doctorHome.TodaysApptsList.SelectedItem!=null)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Appointment appt = doctorHome.TodaysApptsList.SelectedItem as Appointment;
                AppointmentShow(appt.Id);
            }
            else if (doctorHome.VacationsList.SelectedItem != null)
            {
                VacationString vacation= doctorHome.VacationsList.SelectedItem as VacationString;
                VacationShow(vacation.Id);
            }

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
            DrugWindow drugWindow = new DrugWindow(drugId);
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
            Data = appointmentController.GetAppointmentData(doctorId);
            TodaysAppointments = new ObservableCollection<Appointment>(appointmentController.GetTodaysAppointments(doctorId));
            
            InitOxyChart();
            Model.InvalidatePlot(true);
            
        }

        internal void ReportDrug()
        {
            object item =doctorHome.DrugsTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((doctorHome.DrugsTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                DrugReportWindow drugReportWindow = new DrugReportWindow(this, id);
                drugReportWindow.Show();
            }
            else MessageBox.Show("Niste odabrali lek!");
            
        }

        public void RefreshDrugs()
        {
            Drugs = new ObservableCollection<Drug>(drugController.GetValidDrugs());
        }

        public void RefreshVacations()
        {
            Vacations = new ObservableCollection<VacationString>(vacationController.GetDoctorVacationStrings(doctorId));
        }
        internal void PrescriptionShow()
        {
            object item = doctorHome.PassedTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((doctorHome.PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                Appointment appt=appointmentController.GetById(id);
                Patient patient=patientController.GetById(appt.Patient);
                if (patient != null)
                {
                    PrescriptionWindow prescriptionWindow = new PrescriptionWindow(id);
                    prescriptionWindow.Show();
                }
                else MessageBox.Show("Pacijent ne postoji u bazi!!","Interna greška");

            }
            else MessageBox.Show("Niste odabrali pregled!");
            
        }

        public void NewAppointment()
        {
            NewAppointment newAppointment = new NewAppointment(this,0,doctorId,true);
            newAppointment.Show();
        }

        internal void PatientReportForm()
        {
            object item = doctorHome.PatientTable.SelectedItem;
            if (item != null)
            {
                int id=int.Parse((doctorHome.PatientTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                PatientReportForm patientReportForm = new PatientReportForm(id);
                patientReportForm.Show();
            }
            else MessageBox.Show("Niste odabrali pacijenta!");
            
        }

        internal void UpdateAppointment()
        {
            object item = doctorHome.UpcomingTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((doctorHome.UpcomingTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                NewAppointment updateAppointment = new NewAppointment(this, id, doctorId, true);
                updateAppointment.Show();

            }
            else MessageBox.Show("Niste odabrali pregled!");
            
        }

        internal void ScheduleVacation()
        {
            if (doctorHome.vacationRadio.IsChecked == false && doctorHome.sickLeaveRadio.IsChecked == false) { MessageBox.Show("Niste uneli sve potrebne podatke.", "Greška"); return; }
            else if (doctorHome.startDate_tb.Text.Equals("") | doctorHome.endDate_tb.Text.Equals("") | doctorHome.reason_tb.Text.Equals("")) { MessageBox.Show("Niste uneli sve potrebne podatke.", "Greška"); return; } ;
            bool emergency=(bool)doctorHome.emergency_Check.IsChecked;
            int error=vacationController.ScheduleVacation(doctorId,startDate,endDate,reason, emergency);
            RefreshVacations();
            switch (error)
            {
                case 0:
                    MessageBox.Show("Zahtev za slobodne dane je uspešno poslat.", "Obaveštenje");
                    ClearVacationFields();
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


        }

        private void ClearVacationFields()
        {
            doctorHome.startDate_tb.Text = "";
            doctorHome.endDate_tb.Text = "";
            doctorHome.reason_tb.Text = "";
            doctorHome.emergency_Check.IsChecked = false;
            doctorHome.vacationRadio.IsChecked = false;
            doctorHome.sickLeaveRadio.IsChecked = false;

        }

        

        internal void ReportShow()
        {
            object item = doctorHome.PassedTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((doctorHome.PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                Appointment appt=appointmentController.GetById(id);
                Patient patient=patientController.GetById(appt.Patient);
                if (patient != null)
                {
                    ReportWindow reportWindow = new ReportWindow(id, 0, 0, null);
                    reportWindow.Show();
                }
                else MessageBox.Show("Pacijent ne postoji u bazi!", "Interna greška");

            }
            else MessageBox.Show("Niste odabrali pregled!");

            
        }

        internal void DeleteAppt()
        {
            object item = doctorHome.UpcomingTable.SelectedItem;
            int id;
            if (item != null)
                id = int.Parse((doctorHome.UpcomingTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            else
            {
                MessageBox.Show("Niste odabrali pregled!");
                return;
            }
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da obrišete ovaj pregled?", "Upozorenje", button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Delete(id);
                    break;
                case MessageBoxResult.No:
                    return;
            }
           
            
        }

        private void Delete(int id)
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
            RefreshAppointments();
        }





        // PROPERTYCHANGED PUBLIC FIELDS
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
        public List<AppointmentData> Data
        {
            get
            {
                return data;
            }
            set
            {
                if (data == value)
                    return;
                data = appointmentController.GetAppointmentData(doctorId);
                NotifyPropertyChanged("Data");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private PlotModel model;

        public PlotModel Model {
            get
            {
                return model;
            }
            set
            {
                if (model == value)
                    return;
                NotifyPropertyChanged("Model");
            }
        }

        public MyICommand NewAppointmentCommand { get; set; }
        public MyICommand ReferralCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public MyICommand ShowListCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand ReportCommand { get; set; }
        public MyICommand PrescCommand { get; set; }
        public MyICommand DrugReportCommand { get; set; }
        public MyICommand MainTabCommand { get; set; }
        public MyICommand ApptTabCommand { get; set; }
        public MyICommand PatientsTabCommand { get; set; }
        public MyICommand DrugsTabCommand { get; set; }
        public MyICommand VacationTabCommand { get; set; }
        public MyICommand ScheduleVacationCommand { get; set; }
        public MyICommand LogoutCommand { get; set; }


        private void MainTabShow()
        {
            doctorHome.mainTab.IsSelected=true;
        }
        private void ApptTabShow()
        {
            doctorHome.apptTab.IsSelected = true;
        }

        private void PatientsTabShow()
        {
            doctorHome.patientTab.IsSelected = true;
        }
        private void DrugsTabShow()
        {
            doctorHome.drugsTab.IsSelected = true;
        }
        private void VacationTabShow()
        {
            doctorHome.vacationTab.IsSelected = true;
        }

    }
}
