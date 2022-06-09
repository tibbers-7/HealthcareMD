using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HealthcareMD.Controller
{
    public class VacationController
    {
        private VacationService service;

        public VacationController(VacationService service)
        {
            this.service = service;
        }

        internal int ScheduleVacation(int doctorId,string startDate, string endDate, string reason,bool emergency)
        {
            DateOnly _startDate = Tools.ParseDate(startDate);
            DateOnly _endDate = Tools.ParseDate(endDate);
            return service.ScheduleVacation(doctorId,_startDate, _endDate, reason,emergency);
        }

        internal List<VacationString> GetDoctorVacationStrings(int doctorId)
        {
            return service.GetDoctorVacationStrings(doctorId);
        }

        internal Vacation GetById(int vacationId)
        {
            return service.GetById(vacationId);
        }

        internal string GetDoctorInfo(int doctorId)
        {
            return service.GetDoctorInfo(doctorId);
        }

        internal ObservableCollection<VacationRecord> getPendingVacationRecords()
        {
            return service.getPendingVacationRecords();
        }

        internal void processVacation(int id, int option)
        {
            service.processVacation(id, option);

        }

        internal List<VacationString> GetUpcomingVacations(int doctorId)
        {
            return service.GetUpcomingVacations(doctorId);
        }
    }
}
