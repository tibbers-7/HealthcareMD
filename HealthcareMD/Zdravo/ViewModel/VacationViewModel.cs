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
using HealthcareMD.Controller;
using Tools;
using HealthcareMD.DoctorView;

namespace HealthcareMD.ViewModel
{
    internal class VacationViewModel : BindableBase
    {
        private string currentDoctor;
        public string CurrentDoctor { get { return currentDoctor; } set { currentDoctor = value; } }
        private string period;
        public string Period { get { return period; } set { period = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        private string status;
        public string Status { get { return status; } set { status = value; } }
        private VacationController vacationController;

        
        private int vacationId;
        private DateOnly requestDate;
        public string RequestDate { get { return requestDate.ToString(); } set { requestDate = TimeTools.ParseDate(RequestDate); } }
        public MyICommand AcceptCommand { get; set; }
        private VacationWindow vacationWindow;

        public VacationViewModel(VacationWindow vacationWindow, int vacationId)
        {
            var app = Application.Current as App;
            vacationController = app.vacationController;
            this.vacationId = vacationId;
            this.vacationWindow = vacationWindow;
            AcceptCommand = new MyICommand(Accept);
            
            InitFields();
        }

        private void InitFields()
        {
            Vacation vacation = vacationController.GetById(vacationId);
            VacationString vacationString = vacation.ToString();
            if (vacation != null)
            {
                currentDoctor=vacationController.GetDoctorInfo(vacation.DoctorId);
                period = vacationString.Period;
                reason = vacation.Reason;
                status = vacationString.StatusString;
                requestDate = vacation.RequestDate;
            }
        }

        internal void Accept()
        {
            vacationWindow.Close();
        }

    }
}

