using Model;
using System.Collections.ObjectModel;
using HealthcareMD.Controller;
using HealthcareMD.DoctorWindows;

namespace HealthcareMD.ViewModel
{
    internal class ChoosePatientViewModel
    {
        private ObservableCollection<Patient> patients;
        public ObservableCollection<Patient> Patients { get { return patients; } set { patients = value; } }
        private PatientController patientController = new PatientController();

        public ChoosePatientViewModel()
        {
            patients = patientController.GetAll();
        }

        internal void ShowPatient(int id)
        {
            PatientChart chart = new PatientChart(id);
            chart.Show();
        }
    }
}
