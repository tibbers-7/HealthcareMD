using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HealthcareMD_;
using Tools;

namespace Service
{
    public class VacationService
    {
        private VacationRepository repo;
        private DoctorRepository doctorRepo;
        public VacationService(VacationRepository repo,DoctorRepository doctorRepo)
        {
            this.repo = repo;
            this.doctorRepo = doctorRepo;
        }

        internal int ScheduleVacation(int doctorId,DateOnly startDate, DateOnly endDate, string reason,bool emergency)
        {
            if (CheckIsInPast(startDate)) return 1;
            if (!CheckDates(startDate, endDate)) return 2;// Greska; Pocetni datum je posle krajnjeg
            Vacation vacation = new Vacation() { RequestDate=DateOnly.FromDateTime(DateTime.Now), Status=HealthcareMD_.Status.waiting, DoctorId = doctorId, EndDate = endDate, StartDate = startDate, Reason = reason, Emergency = emergency };
            if (!emergency)
            {
                if (!Check48h(startDate)) return 3; //Greska: nije 48h ranije
                if (!CheckSpecialization(doctorId, vacation)) return 4; //Greska; Ima vise od dva doktora iste spec koji su zakazali 
            }
            return repo.AddNew(vacation);
        }

        internal ObservableCollection<VacationRecord> getPendingVacationRecords()
        {
            return repo.getPendingVacationRecords();
        }

        internal void processVacation(int id, int option)
        {
            repo.processVacation(id, option);
        }

        internal List<VacationString> GetUpcomingVacations(int doctorId)
        {
            List<VacationString> vacationStrings = new List<VacationString>();
            foreach(VacationString vacationString in GetDoctorVacationStrings(doctorId))
            {
                if (!TimeTools.IsInPast(vacationString.vacation.EndDate, new TimeOnly(0, 0)))
                    vacationStrings.Add(vacationString);
            }
            return vacationStrings;
        }

        internal string GetDoctorInfo(int doctorId)
        {
            return doctorRepo.GetDoctorInfo(doctorId);
        }

        internal Vacation GetById(int vacationId)
        {
            return repo.GetById(vacationId);
        }

        internal List<VacationString> GetDoctorVacationStrings(int doctorId)
        {
            return repo.GetDoctorVacationStrings(doctorId);
        }

        private bool CheckIsInPast(DateOnly startDate)
        {
            
            int cmp = DateTime.Compare(DateTime.Now,startDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (cmp > 0) return true;
            return false;
        }

        private bool CheckDates(DateOnly startDate,DateOnly endDate)
        {
            int startDateEndDate = DateTime.Compare(startDate.ToDateTime(TimeOnly.Parse("00:00 AM")), endDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (startDateEndDate > 0) return false;
            return true;
        }

        private bool CheckSpecialization(int doctorId,Vacation newVacation)
        {
            Doctor d=doctorRepo.getById(doctorId);
            int counter = 0;
            foreach (Vacation oldVacation in repo.GetAll())
            {
                Doctor doctor = doctorRepo.getById(oldVacation.DoctorId);
                if (doctor.Specialization.Equals(d.Specialization) && doctor.Id != d.Id && oldVacation.Status != HealthcareMD_.Status.denied)
                {
                    if (FindVacationConflicts(newVacation, oldVacation)) counter++;
                }

            }

            if (counter > 1) return false;
            return true;
        }

        internal static bool FindVacationConflicts(Vacation newVacation, Vacation oldVacation)
        {
            DateTime newStartDate = newVacation.StartDate.ToDateTime(TimeOnly.Parse("00:00 AM"));
            DateTime newEndDate = newVacation.EndDate.ToDateTime(TimeOnly.Parse("00:00 AM"));
            DateTime oldStartDate = oldVacation.StartDate.ToDateTime(TimeOnly.Parse("00:00 AM"));
            DateTime oldEndDate = oldVacation.EndDate.ToDateTime(TimeOnly.Parse("00:00 AM"));

            int newEndOldStart = DateTime.Compare(oldStartDate, newEndDate);
            int newStartOldEnd = DateTime.Compare(newStartDate, oldEndDate);
            int newStartOldStart = DateTime.Compare(newStartDate, oldStartDate);
            int newEndOldEnd = DateTime.Compare(newEndDate, oldEndDate);

            if (newStartOldStart == 0) return true; // old and new start at the same date
            if (newStartOldStart >= 0 && newStartOldEnd <= 0) return true; //new starts after old starts and old ends after new starts 
            if (newStartOldStart <= 0 && newEndOldStart <= 0) return true; //old starts after new starts, old ends after new ends
            if (newStartOldStart <= 0 && newEndOldEnd >= 0) return true; //old date is inside new date
            if (newStartOldStart >= 0 && newEndOldEnd <= 0) return true; //old date encapsulates new date

            return false;
        }

        private bool Check48h(DateOnly startDate)
        {
            DateTime twoDaysLater = DateTime.Now.AddDays(2);
            int cmp = DateTime.Compare(twoDaysLater, startDate.ToDateTime(TimeOnly.Parse("00:00 AM")));
            if (cmp > 0) return false;
            return true;
        }

    }
}
