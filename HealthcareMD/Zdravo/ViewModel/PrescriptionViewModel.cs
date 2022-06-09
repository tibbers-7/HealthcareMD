using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using HealthcareMD.Controller;
using HealthcareMD.DoctorView;

namespace HealthcareMD.ViewModel
{
    internal class PrescriptionViewModel
    {
        private int appointmentId;
        private ObservableCollection<Drug> drugs;
        public string SelectedDrug { get; set; }
        public ObservableCollection<Drug> Drugs { get { return drugs; } set { drugs = value; } }
        private AppointmentController appointmentController;
        private DrugController drugController;
        private int errorCode;

        public PrescriptionViewModel(int appointmentId)
        {
            var app = Application.Current as App;
            appointmentController = app.appointmentController;
            drugController=app.drugController;
            this.appointmentId = appointmentId;
            drugs = new ObservableCollection<Drug>(drugController.GetAllDrugs());
            drugs = appointmentController.SetAllergies(drugs,appointmentId);


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

        internal int AddPrescription(int drugId)
        {
            Appointment appt= appointmentController.GetById(appointmentId);
            return appointmentController.AddPrescription(appt.Patient,drugId);
        }

        internal int ShowDrug(int drugId)
        {
            Drug drug=drugController.GetById(drugId);
            if (drug == null) return -1;
            DrugWindow drugWindow = new DrugWindow(null, drugId);
            drugWindow.Show();
            return 0;
        }
    }
}
