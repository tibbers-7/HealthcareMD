/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Darko
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Model;
using Repository;
using System;
using System.Collections.ObjectModel;

namespace Service
{

    public class PatientService

   {

        private PatientRepository p;
        private DoctorRepository doctorRepository;
        public PatientService()
        {
            p = new PatientRepository();
            ReportRepository reportRepository = new ReportRepository();
            PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
            doctorRepository = new DoctorRepository();

            foreach (Report report in reportRepository.GetReports())
            {
                if(p.GetById(report.PatientId)!=null) p.GetById(report.PatientId).AddReport(report);
            }

            foreach(Prescription presc in prescriptionRepository.prescriptions)
            {
                if (p.GetById(presc.PatientId) != null) p.GetById(presc.PatientId).AddPrescription(presc);
            }


        }
        public string checkId()
        {
            
            ObservableCollection<Patient> patients = p.GetAll();
            int sifra = 0;
            for(int i = 0; i < patients.Count; i++)
            {
                if (i == patients.Count - 1) sifra = i+2;
            }
            return sifra.ToString();
        }

        public void removeAllergen(Patient patient,Allergen allergen)
        {
            p = new PatientRepository();
            p.removeAllergen(patient,allergen);
        }
        internal ObservableCollection<Prescription> GetPrescriptions(int patientId)
        {
            Patient patient = p.GetById(patientId);
            return new ObservableCollection<Prescription>(patient.Prescriptions);
        }

        internal ObservableCollection<Patient> GetAll()
        {
            return p.GetAll();
        }

        internal Patient GetById(int patientId)
        {
            return p.GetById(patientId);
        }

        internal ObservableCollection<Report> GetReports(int patientId)
        {
            Patient patient = p.GetById(patientId);
            return new ObservableCollection<Report>(patient.Reports);
        }

        internal Doctor GetChosenDoctor(string doctorSpecialty,int patientId)
        {
            
            Patient patient=p.GetById(patientId);
            Doctor doctor=new Doctor();
            foreach (int doctorId in patient.ChosenDoctors)
            {
                if (doctorId != 0) doctor = doctorRepository.getById(doctorId);
                else doctor = doctorRepository.FindBySpecialization(doctorSpecialty);
            }

            return doctor;
        }

    }

        
 }
