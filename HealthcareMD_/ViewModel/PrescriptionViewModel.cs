using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using HealthcareMD_.Controller;
using HealthcareMD_.DoctorView;
using Tools;
using HealthcareMD_.DoctorWindows;
using System.Windows.Controls;

namespace HealthcareMD_.ViewModel
{
    internal class PrescriptionViewModel : BindableBase
    {
        private int appointmentId;
        private ObservableCollection<Drug> drugs;
        public string SelectedDrug { get; set; }
        public ObservableCollection<Drug> Drugs { get { return drugs; } set { drugs = value; } }
        private AppointmentController appointmentController;
        private DrugController drugController;
        private int errorCode;
        public MyICommand AcceptCommand { get; set; }
        public MyICommand ShowCommand { get; set; }
        public MyICommand CloseCommand { get; set; }
        private PrescriptionWindow callerWindow;
        public PrescriptionViewModel(PrescriptionWindow callerWindow, int appointmentId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            drugController=app.drugController;
            this.appointmentId = appointmentId;
            this.callerWindow = callerWindow;
            drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs());
            drugs = appointmentController.SetAllergies(drugs,appointmentId);
            AcceptCommand = new MyICommand(Accept);
            ShowCommand = new MyICommand(ShowDrug);
            CloseCommand = new MyICommand(Close);

        }

        internal void Close()
        {
            callerWindow.Close();
        }

        public int CheckAllergies(int drugId)
        {
            if (!appointmentController.CheckAllergies(drugId,drugs))
            {
               errorCode=AddPrescription(drugId);
               if (errorCode == 0) MessageBox.Show("Uspešno unet recept!", "Obaveštenje");
               else MessageBox.Show("Neuspešan upis u datoteku!", "Interna greška");
            }
            else
            {
               MessageBox.Show("Pacijent je alergičan na lek! Molimo Vas da odaberete drugi lek.","Upozorenje");
                errorCode = -1;
            }
            return errorCode;
        }

        internal void Accept()
        {
            object item = callerWindow.drugTable.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Niste odabrali lek!", "Greška");
            }
            else
            {
                int chosenDrug = int.Parse((callerWindow.drugTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (CheckAllergies(chosenDrug) == 0) callerWindow.Close();

            }
        }

        internal int AddPrescription(int drugId)
        {
            Appointment appt= appointmentController.GetById(appointmentId);
            return appointmentController.AddPrescription(appt.Patient,drugId);
        }

        internal void ShowDrug()
        {
            object item = callerWindow.drugTable.SelectedItem;
            int drugId=int.Parse((callerWindow.drugTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            
            Drug drug=drugController.GetById(drugId);
            if (drug == null) { MessageBox.Show("Lek ne postoji u bazi!", "Interna greška"); return; };
            DrugWindow drugWindow = new DrugWindow(null, drugId);
            drugWindow.Show();
        }
    }
}
