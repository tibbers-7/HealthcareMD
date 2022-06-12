using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD_.FileHandler;
using Model;
using System.Collections.ObjectModel;

namespace Repository
{
    public class VacationRepository
    {
        private readonly VacationFileHandler fileHandler=new VacationFileHandler();
        private List<Vacation> vacations;
        private List<VacationString> vacationStrings;
        private int errorCode;
        private DoctorRepository doctorRepository;

        public VacationRepository(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
            InitVacations();
        }

        public void InitVacations()
        {
            List<object> vacationList = fileHandler.Read();

            vacationStrings = new List<VacationString>();
            vacations = new List<Vacation>();
            foreach (object vacationObj in vacationList)
            {
                Vacation vacation=(Vacation)vacationObj;
                VacationString vacString = vacation.ToString();
                vacationStrings.Add(vacString);
                vacations.Add(vacation);
            }
            
        }

        public Vacation GetById(int id)
        {
            foreach (Vacation vacation in vacations)
            {
                if (vacation.Id == id) return vacation;
            }
            return null;
        }

        public int AddNew(Vacation vacation)
        {
            
            vacation.Id = vacations.Last().Id+1;

            int listCount = vacations.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = vacations[i].ToCSV();
            }
            newLines[listCount] = vacation.ToCSV();
            errorCode= fileHandler.Write(newLines);
            InitVacations();
            return errorCode;
        }

        internal void processVacation(int id, int option)
        {
            foreach (Vacation vacation in vacations)
            {
                if (vacation.Id == id)
                {
                    if (option == 1) vacation.Status = HealthcareMD_.Status.accepted;
                    else vacation.Status = HealthcareMD_.Status.denied;
                }
            }
            int listCount = vacations.Count;
            string[] newLines = new string[listCount];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = vacations[i].ToCSV();
            }
            fileHandler.Write(newLines);
            InitVacations();
        }

        internal ObservableCollection<VacationRecord> getPendingVacationRecords()
        {
            ObservableCollection<VacationRecord> records = new ObservableCollection<VacationRecord>();
            foreach (Vacation vacation in vacations)
            {
                if (vacation.Status == HealthcareMD_.Status.waiting)
                {
                    Doctor doctor = doctorRepository.getById(vacation.DoctorId);
                    //startDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy");
                    string period = vacation.StartDate.ToString("dd/MM/yyyy") + "-" + vacation.EndDate.ToString("dd/MM/yyyy");
                    records.Add(new VacationRecord(vacation.Id, doctor.Name + " " + doctor.LastName, doctor.Specialization, period, vacation.Reason));
                }
            }
            return records;
        }

        internal List<VacationString> GetDoctorVacationStrings(int doctorId)
        {
            List<VacationString> vacStrings = new List<VacationString>();
            foreach(VacationString vacationString in vacationStrings)
            {
                if(vacationString.DoctorId==doctorId) vacStrings.Add(vacationString);
            }
            return vacStrings;
        }

        internal List<Vacation> GetAll()
        {
            InitVacations();
            return vacations;
        }

        

        internal void RemoveOldLogs()
        {
            List<Vacation> currentVacations = new List<Vacation>();
            foreach(Vacation vacation in vacations)
            {
                int cmp = DateTime.Compare(DateTime.Now, vacation.EndDate.ToDateTime(TimeOnly.Parse("00:00 PM")));
                if (cmp <= 0) currentVacations.Add(vacation);
            }

            vacations = currentVacations;
        }
    }
}
