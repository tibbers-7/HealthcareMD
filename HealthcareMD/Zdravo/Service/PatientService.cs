/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Darko
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using HealthcareMD;
using HealthcareMD.FileHandler;
using HealthcareMD.Repository;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Service
{

    public class PatientService

   {

        private PatientRepository p;
        private DoctorRepository doctorRepository;
        private DrugRepository drugRepository;
        private List<string> prescLines;
        private List<string> reportLines;
        private string info;
        public PatientService(DrugRepository drugRepository,PatientRepository patientRepository,DoctorRepository doctorRepository)
        {
            this.drugRepository = drugRepository;
            p = patientRepository;
            


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

        internal void GetPatientReport(int patientId, string startDateString, string endDateString)
        {
            ReportPDF reportPdfWriter = new ReportPDF();
            Patient patient= GetById(patientId);
            p.BindReports();
            p.BindPrescriptions();

            GetReportLines(patient, Tools.ParseDate(startDateString), Tools.ParseDate(endDateString));

            string fileName = patient.Ime + patient.Prezime + "_" + DateOnly.FromDateTime(DateTime.Now).ToString("dd.MM.yyyy")+".pdf";
            reportPdfWriter.CreateReport(info,reportLines,prescLines,fileName);
            
        }

        internal void GetReportLines(Patient patient,DateOnly startDate, DateOnly endDate)
        {
            reportLines = new List<string>();
            prescLines = new List<string>();
            info=patient.Ime + " " + patient.Prezime + " : " + startDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy");

            int reportCount=1;
            foreach (Report report in patient.Reports)
            {
                if (Tools.IsDateBetween(report.Date, startDate, endDate))
                {
                    reportLines.AddRange(report.GetReportInfo(reportCount++));
                    reportLines.Add("\n");
                }
            }

            int prescCount = 1;
            foreach (Prescription prescription in patient.Prescriptions)
            {
                if (Tools.IsDateBetween(prescription.Date, startDate, endDate))
                {
                    string drugName = drugRepository.GetById(prescription.DrugId).Name;
                    prescLines.AddRange(prescription.GetPrescriptionInfo(drugName,prescCount++));
                    prescLines.Add("\n");
                }
            }

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
