using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;

namespace HealthcareMD.ViewModel
{
    public class PatientsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Patient> patients;
        PatientFileHandler p;
        public event PropertyChangedEventHandler PropertyChanged;
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
                patients = new ObservableCollection<Patient>(p.read());
                NotifyPropertyChanged("Patients");
            }
        }

        public PatientsViewModel()
        {
            p = new PatientFileHandler();
            patients = new ObservableCollection<Patient>(p.read());
        }
        public void Refresh()
        {
            patients = new ObservableCollection<Patient>(p.read());
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
