using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD_.Controller;
using System.Windows;
using System.Windows.Controls;
using Model;

namespace HealthcareMD_.ViewModel
{
    internal class DrugReportViewModel
    {
        private int drugId;
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        private DrugController drugController;
        private int errorCode;

        public DrugReportViewModel(int drugId)
        {
            this.drugId = drugId;
            var app = Application.Current as App;
            drugController = app.drugController;
            Drug d = drugController.GetById(drugId);
            name= d.Name;
        }

        internal int CreateDrugReport()
        {
            drugController.CreateDrugReport(drugId, reason);
            errorCode= drugController.ChangeStatus(false, drugId);
            switch (errorCode)
            {
                case 0:
                    MessageBox.Show("Uspešno ste prijavili lek!", "Obaveštenje");
                    break;
                case 1:
                    MessageBox.Show("Lek ne postoji u bazi!", "Interna greška");
                    break;
                case -1:
                    MessageBox.Show("Neuspešan upis u datoteku!", "Interna greška");
                    break;
            }
            return errorCode;
        }
    }
}
