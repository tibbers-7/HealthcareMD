using HealthcareMD.Controller;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.ViewModel
{
    internal class ReportFormViewModel
    {
        private int patientId;
        private string startDate;
        public string StartDate { get { return startDate; } set { startDate = value; } }
        private string endDate;
        public string EndDate { get { return endDate; } set { endDate = value; } }
        private PatientController patientController;
       
        public ReportFormViewModel(int patientId)
        {
            this.patientId = patientId;
            var app = Application.Current as App;
            patientController = app.patientController;
        }

        internal void GetReport()
        {
            patientController.GetPatientReport(patientId, StartDate, EndDate);
            
        }
    }
}
