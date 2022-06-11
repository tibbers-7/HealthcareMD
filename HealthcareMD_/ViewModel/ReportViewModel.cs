using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows;
using System.Windows.Controls;
using HealthcareMD_.Controller;
using Tools;
using HealthcareMD_.DoctorWindows;

namespace HealthcareMD_.ViewModel
{
    internal class ReportViewModel : BindableBase 
    {
        
        private int apptId;
        private int reportId;
        private int patientId;
        private string date;
        public string Date { get { return date; } set { date = value; } }
        private string diagnosis;
        public string Diagnosis { get { return diagnosis; } set { diagnosis = value; } }
        private string reportString;
        public string ReportString { get { return reportString; } set { reportString = value; } }
        private AppointmentController appointmentController;
        private string anamnesis;
        public string Anamnesis { get { return anamnesis; } set { anamnesis = value; } }
        public MyICommand AcceptCommand { get; set; }
        public MyICommand CloseCommand { get; set; }
        private ReportWindow callerWindow;
        public ReportViewModel(ReportWindow callerWindow,int apptId,int reportId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            this.apptId = apptId;
            this.reportId = reportId;
            this.callerWindow = callerWindow;
            AcceptCommand = new MyICommand(Accept);
            CloseCommand = new MyICommand(Close);
            InitFields();
        }

        private void InitFields()
        {
            if (reportId != 0)
            {
                Report r = appointmentController.GetReport(reportId);
                date = r.Date.ToString("dd/MM/yyyy");
                diagnosis = r.Diagnosis;
                reportString = r.ReportString;
                patientId = r.PatientId;
                anamnesis = r.Anamnesis;
            }
            else
            {
                date = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        internal void Close()
        {
            callerWindow.Close();   
        }

        internal void Accept()
        {
            int operation=callerWindow.operation;
            
            int errorCode=0;
            switch (operation)
            {
                //Add report
                case 0:
                    errorCode=appointmentController.CreateReport(apptId, date, diagnosis, reportString,anamnesis);
                    break;
                case 1: 
                    errorCode=appointmentController.UpdateReport(patientId,reportId, date, diagnosis, reportString,anamnesis);
                    break;
            }
            switch (errorCode)
            {
                case -1:
                    MessageBox.Show("Neuspešan upis u fajl!", "Interna greška");
                    break;
                case 1:
                    MessageBox.Show("Pregled ne postoji u bazi!", "Interna greška");
                    break;
                case 2:
                    MessageBox.Show("Pacijent ne postoji u bazi!", "Interna greška");
                    break;
            }

            if (callerWindow.callerWindow != null) callerWindow.callerWindow.RefreshTables();
            callerWindow.Close();

        }
    }
}
