/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Darko
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using HealthcareMD_;
using HealthcareMD_.FileHandler;
using HealthcareMD_.Repository;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using Tools;

namespace Service
{

    public class PatientService

   {

        private PatientRepository patientRepository;
        private DoctorRepository doctorRepository;
        private DrugRepository drugRepository;
        private List<string> prescLines;
        private List<string> reportLines;
        private string info;

        public PatientService(DrugRepository drugRepository,PatientRepository patientRepository,DoctorRepository doctorRepository)
        {
            this.drugRepository = drugRepository;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;

            
        }
        public string checkId()
        {
            
            List<Patient> patients = patientRepository.GetAll();
            int sifra = 0;
            for(int i = 0; i < patients.Count; i++)
            {
                if (i == patients.Count - 1) sifra = i+2;
            }
            return sifra.ToString();
        }

        internal ObservableCollection<Prescription> GetPrescriptions(int patientId)
        {
            Patient patient = GetById(patientId);
            return new ObservableCollection<Prescription>(GetById(patientId).Prescriptions);
        }

        internal void GetPatientReport(Patient patient, DateOnly startDate, DateOnly endDate)
        {
            ReportPDF reportPdfWriter = new ReportPDF();

            GetReportLines(patient, startDate , endDate);

            string fileName = patient.Ime + patient.Prezime + "_" + startDate.ToString("dd.MM.yyyy")+"-"+endDate.ToString("dd.MM.yyyy")+".pdf";
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
                if (TimeTools.IsDateBetween(report.Date, startDate, endDate))
                {
                    reportLines.AddRange(report.GetReportInfo(reportCount++));
                    reportLines.Add("\n");
                }
            }

            int prescCount = 1;
            foreach (Prescription prescription in patient.Prescriptions)
            {
                if (TimeTools.IsDateBetween(prescription.Date, startDate, endDate))
                {
                    string drugName = drugRepository.GetById(prescription.DrugId).Name;
                    prescLines.AddRange(prescription.GetPrescriptionInfo(drugName,prescCount++));
                    prescLines.Add("\n");
                }
            }

        }

        internal List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        internal Patient GetById(int patientId)
        {
            return patientRepository.GetById(patientId);
        }

        internal ObservableCollection<Report> GetReports(int patientId)
        {
            return new ObservableCollection<Report>(GetById(patientId).Reports);
        }

        internal Doctor GetChosenDoctor(string doctorSpecialty,int patientId)
        {
            
            Patient patient=patientRepository.GetById(patientId);
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
