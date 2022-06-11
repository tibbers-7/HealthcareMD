using HealthcareMD_.Controller;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using HealthcareMD_.View;

namespace HealthcareMD_.ViewModel
{
    internal class ReportFormViewModel : BindableBase 
    {
        private int patientId;
        private string startDate;
        public string StartDate { get { return startDate; } set { startDate = value; } }
        private string endDate;
        public string EndDate { get { return endDate; } set { endDate = value; } }
        private PatientController patientController;
        private string patientName;
        public string PatientName { get { return patientName; } set { patientName = value;} }
        public MyICommand AcceptCommand { get; set; }
        public MyICommand CloseCommand { get; set; }
        PatientReportForm callerWindow;

        public ReportFormViewModel(PatientReportForm callerWindow, int patientId)
        {
            this.patientId = patientId;
            var app = Application.Current as App;
            this.callerWindow = callerWindow;
            AcceptCommand = new MyICommand(Accept);
            CloseCommand = new MyICommand(Close);
            patientController = app.patientController;
            patientName=patientController.GetFullName(patientId);
        }
        internal void Accept()
        {
            if (callerWindow.startDate_tb.Text != "" && callerWindow.endDate_tb.Text != "") { GetReport(); Close(); }
            else MessageBox.Show("Niste uneli sve potrebne podatke!", "Greška");
            
        }

        internal void Close()
        {
            callerWindow.Close();
        }
        internal void GetReport()
        {
            patientController.GetPatientReport(patientId, StartDate, EndDate);
            MessageBox.Show("Dokument možete pronaći na putanji: Zdravo\\bin\\Reports");
            
        }
    }
}
