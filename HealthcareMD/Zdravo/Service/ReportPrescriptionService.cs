using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.Service
{
    public class ReportPrescriptionService
    {
        private ReportRepository reportRepo;
        private PatientRepository patientRepo;
        private PrescriptionRepository prescriptionRepo;
        private int errorCode;

        public ReportPrescriptionService(ReportRepository reportRepo, PatientRepository patientRepo,PrescriptionRepository prescriptionRepo)
        {
            this.reportRepo = reportRepo;
            this.patientRepo = patientRepo;
            this.prescriptionRepo = prescriptionRepo;
        }
        internal int AddReport(Report rpt)
        {
            return reportRepo.AddNew(rpt);
        }

        internal Report GetReportById(int id)
        {
            return reportRepo.GetById(id);
        }

        internal int CreateReport(Appointment appt, Report report)
        {
            if (appt == null) return 1;
            errorCode =AddReport(report);
            if (errorCode == 0) errorCode=patientRepo.AddReport(appt.Patient, report);
            return errorCode;
        }

        internal int UpdateReport(int patientId, int reportId, DateOnly date, string diagnosis, string reportString, string anamnesis)
        {
            Report rpt = new Report() { PatientId = patientId, Id = reportId, ReportString = reportString, Diagnosis = diagnosis, Date = date, Anamnesis = anamnesis };
            int errorCode = reportRepo.Update(rpt); //updating in file
            patientRepo.UpdateReport(rpt, patientId); //updating in patient list
            return errorCode;

        }
        internal int AddPrescription(Prescription p, int drugId)
        {
            p.DrugId = drugId;
            return prescriptionRepo.AddNew(p);
        }

        public bool IsReportAvailable(Appointment appt)
        {
            DateTime datetime = appt.Date.ToDateTime(appt.Time);
            if (DateTime.Compare(DateTime.Now, datetime) > 0) return true;
            return false;
        }
    }
}
