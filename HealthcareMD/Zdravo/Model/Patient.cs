/***********************************************************************
 * Module:  Patient.cs
 * Author:  Darko
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/

using System;
using System.Collections.Generic;
using HealthcareMD;
using System.Collections.ObjectModel;
using Repository;

namespace Model
{
   public class Patient : User
   {
        private List<Appointment> appointments;
        public List<Appointment> Appointments { get { return appointments; } set { appointments = value; } }
        private List<Prescription> prescriptions;
        public List<Prescription> Prescriptions { get { return prescriptions; } set { prescriptions = value; } }

        private ObservableCollection<Allergen> allergens;
        public ObservableCollection<Allergen> Allergens { get { return allergens; } set { allergens = value; } }

        private List<int> allergenIds;
        private List<int> AllergenIds { get { return allergenIds; } set { allergenIds = value; } }

        private string workPlace;
        private List<Report> reports;
        public List<Report> Reports { get { return reports; } set { reports = value; } }
        public string WorkPlace { get { return workPlace; } set { workPlace = value; } }
        private MarriageStatus status;
        public MarriageStatus Status { get { return status; } set { status = value; } }
        private List<int> chosenDoctors;
        public List<int> ChosenDoctors { get { return chosenDoctors; } set { chosenDoctors = value;} }
        public Patient(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu,string mejl,List<int> allergenIds) :base(fn,ln,i,un,pas,pn,date,g,ad,gu,mejl)
        {
            reports = new List<Report>();
            appointments = new List<Appointment>();
            prescriptions = new List<Prescription>();
            AllergenRepository repo = new AllergenRepository();
            ObservableCollection<Allergen> allAllergens = repo.getAllAllergens();
            ObservableCollection<Allergen> allergeniPacijenta = new ObservableCollection<Allergen>();
                List<int> ids = allergenIds;

                foreach (Allergen a in allAllergens)
                {
                    foreach (int allergenId in ids)
                    {
                        if (allergenId == a.Id) allergeniPacijenta.Add(a);
                    }
                }

            this.allergens = allergeniPacijenta;
        }
        public Patient(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu, string mejl) : base(fn, ln, i, un, pas, pn, date, g, ad, gu, mejl)
        {
            reports = new List<Report>();
            appointments = new List<Appointment>();
            prescriptions = new List<Prescription>();

        }
        internal ObservableCollection<string> GetAllergens()
        {
            ObservableCollection<string> res = new ObservableCollection<string>();
            foreach(Allergen a in allergens)
            {
                res.Add(a.Name);
            }
            return res;
        }

        /* public Patient(string fn, string ln, int i, string un, string pas, string pn, DateTime date, Gender g, string ad, bool gu, string mejl) : base(fn, ln, i, un, pas, pn, date, g, ad, gu, mejl)
{
    appointments = new List<Appointment>();
    prescriptions = new List<Prescription>();
    reports = new List<Report>();
    this.allergens = new ObservableCollection<Allergen>() { new Allergen(1, "bez", "B") };
}*/
        public void AddReport(Report rpt)
        {
            reports.Add(rpt);
        }
        internal void AddAppt(Appointment appt)
        {
            appointments.Add(appt);
        }

        internal void RemoveAppt(Appointment appt)
        {
            appointments.Remove(appt);
        }

        public void AddPrescription(Prescription p)
        {
            prescriptions.Add(p);
        }

        
   }
}