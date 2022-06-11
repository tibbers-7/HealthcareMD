/***********************************************************************
 * Module:  PatientRepository.cs
 * Author:  Darko
 * Purpose: Definition of the Class Repository.PatientRepository
 ***********************************************************************/

using Model;
using FileHandler;
using System.Collections.ObjectModel;
using HealthcareMD.FileHandler;
using System.Collections.Generic;
using System;

namespace Repository
{
    public class PatientRepository
   {
      private List<Patient> patients;
        private ReportRepository reportRepo;
        private PrescriptionRepository prescRepo;
        private List<ChosenDoctors> chosenDoctors;

        public PatientRepository(ReportRepository reportRepository, PrescriptionRepository prescRepository)
        {
            fileHandler = new PatientFileHandler();
            patients = fileHandler.read();
            this.reportRepo = reportRepository;
            this.prescRepo = prescRepository;
            BindDoctors();
            Init();
        }

        private void Init()
        {
            foreach (Report report in reportRepo.GetReports())
            {
                if (GetById(report.PatientId) != null) GetById(report.PatientId).AddReport(report);
            }

            foreach (Prescription presc in prescRepo.prescriptions)
            {
                if (GetById(presc.PatientId) != null) GetById(presc.PatientId).AddPrescription(presc);
            }
        }
        internal void BindDoctors()
        {
            InitChosenDoctors();
            foreach (Patient patient in patients) {
                foreach (ChosenDoctors chosenDoctor in chosenDoctors)
                {
                    if (chosenDoctor.PatientId == patient.Id) patient.ChosenDoctors = chosenDoctor.ChosenDoctorIds;

                }
            }
        }


        private void InitChosenDoctors()
        {
            ChosenDoctorsFileHandler chosenDoctorsFileHandler = new ChosenDoctorsFileHandler();
            List<object> list = chosenDoctorsFileHandler.Read();
            chosenDoctors = new List<ChosenDoctors>();
            foreach(object doctorObj in list)
            {
                ChosenDoctors doctors = (ChosenDoctors)doctorObj;
                chosenDoctors.Add(doctors);
            }
        }

        public Patient GetById(int id)
      {
         foreach(Patient patient in patients)
            {
                if(patient.Id == id) return patient;
            }
         return null;
      }
      public void removeAllergen(Patient patient,Allergen allergen)
        {
            fileHandler = new PatientFileHandler();
            patient.Allergens.Remove(allergen);
            fileHandler.updatePatient(patient);
        }
      public List<Patient> GetAll() { 

            return patients;
      }
      
       public bool DeleteById(int id)
        {
            // TODO: implement
         fileHandler = new PatientFileHandler();
         fileHandler.deleteById(id);
         return false;
       }
        public void addPatient(Patient p)
        {
            fileHandler = new PatientFileHandler();
            fileHandler.addPatient(p);
        }
        public void updatePatient(Patient p)
        {
            fileHandler = new PatientFileHandler();
            fileHandler.updatePatient(p);
        }
        private PatientFileHandler fileHandler;

        internal void RemoveReport(int patientId, int reportId)
        {
            foreach(Patient p in patients)
            {
                if (p.Id == patientId)
                {
                    p.Reports.Remove(reportRepo.GetById(reportId));
                }
            }
        }

        internal int AddReport(int patientId, Report report)
        {
            Patient patient = GetById(patientId);
            if (patient == null) return 2;
            patient.AddReport(report);
            return 0;
        }

        internal void UpdateReport(Report report,int patientId)
        {
            foreach(Patient patient in patients)
            {
                if (patient.Id == patientId)
                {
                    patient.Reports.Remove(reportRepo.GetById(report.Id));
                    patient.Reports.Add(report);
                }
            }
        }
    }
}