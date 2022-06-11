using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using Repository;
using HealthcareMD_.Repository;
using System.Windows;
using HealthcareMD_.Controller;

namespace HealthcareMD_.ViewModel
{
    public class AppointmentRecordViewModel
    {
        private ObservableCollection<AppointmentRecord> records;
        // private AllergenService service;
        //     private Patient patient;
        //    private AllergenRepository repo;
        private AppointmentController controller;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AppointmentRecord> Records
        {
            get
            {
                return records;
            }
            set
            {
                if (records == value)
                    return;
                records = controller.GetAllRecords();
                NotifyPropertyChanged("Records");
            }
        }
        public AppointmentRecordViewModel()
        {
            //  service = new AllergenService();
            var app = Application.Current as App;
            controller = app.appointmentController;
            //   repo=new AllergenRepository();
            records = controller.GetAllRecords();
        }
        public AppointmentRecordViewModel(ObservableCollection<AppointmentRecord> rec)
        {
            //  service = new AllergenService();

            //   repo=new AllergenRepository();
            var app = Application.Current as App;
            controller = app.appointmentController;
            records = rec;
        }
        public void Refresh()
        {
            records = controller.GetAllRecords();
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
