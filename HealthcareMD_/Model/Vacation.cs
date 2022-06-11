using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HealthcareMD_;

namespace Model
{
    public class VacationString
    {
        public Vacation vacation;
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private int doctorId;
        public int DoctorId { get { return doctorId; } set { doctorId = value; } }
        private string period;
        public string Period { get { return period; } set { period = value; } }
        private VacationStatus status;
        public VacationStatus Status { get { return status; } set { status = value; } }
        private string statusString;
        public string StatusString { get { return statusString; } set { statusString = value; } }
        private string statusView;
        public string StatusView { get { return statusView; } set { statusView = value; } }
    }
    public class Vacation
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private int doctorId;
        public int DoctorId { get { return doctorId; } set { doctorId = value; } }
        private DateOnly startDate;
        public DateOnly StartDate { get { return startDate; } set { startDate = value; } }
        private DateOnly endDate;
        public DateOnly EndDate { get { return endDate; } set { endDate = value; } }
        private Status status;
        public Status Status { get { return status; } set { status = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }
        private bool emergency;
        public bool Emergency { get { return emergency; } set { emergency = value; } }
        private string deniedReason;
        private DateOnly requestDate;
        public DateOnly RequestDate { get { return requestDate; } set { requestDate = value; } }
        
        public void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            doctorId = int.Parse(csvValues[2].Value);
            startDate= DateOnly.Parse(csvValues[3].Value);
            endDate = DateOnly.Parse(csvValues[4].Value);
            reason=csvValues[5].Value;
            if (csvValues[6].Value.Equals("Y")) emergency = true; else emergency = false;
            switch (csvValues[7].Value)
            {
                case "A":
                    status = Status.accepted;
                    break;
                case "D":
                    status = Status.denied;
                    break;
                default:
                    status = Status.waiting;
                    break;
            }
            requestDate=DateOnly.Parse(csvValues[8].Value);
            deniedReason=csvValues[9].Value;
        }

        internal string ToCSV()
        {
            char _status,_emergency;
            switch (status)
            {
                case Status.accepted:
                    _status='A';
                    break;
                case Status.denied:
                    _status='D';
                    break;
                default:
                    _status = 'W';
                    break;
            }
            if (emergency) _emergency = 'Y'; else _emergency = 'N';
            string res = '#' + id.ToString()+ '#' + doctorId.ToString() + "#" + startDate.ToString() + "#" + endDate.ToString() + "#"+ reason.ToString()+ "#" + _emergency + "#" + _status + "#" + requestDate.ToString() + "#" + deniedReason;
            return res;
        }
        
        internal VacationString ToString()
        {
            VacationString vacString = new VacationString();
            vacString.vacation = this;
            vacString.Period =startDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy");
            vacString.Id=id;
            vacString.DoctorId = doctorId;
            
                switch (status)
                {
                    case HealthcareMD_.Status.accepted:
                        vacString.Status = HealthcareMD_.VacationStatus.accepted;
                        vacString.StatusString = "ODOBRENO";
                        vacString.StatusView = vacString.StatusString;
                        break;
                    case HealthcareMD_.Status.denied:
                        vacString.Status = HealthcareMD_.VacationStatus.denied;
                        vacString.StatusString = "ODBIJENO;\n" + deniedReason;
                        vacString.StatusView = "ODBIJENO";
                        break;
                    default:
                        vacString.Status = HealthcareMD_.VacationStatus.waiting;
                        vacString.StatusString = "NA ČEKANJU";
                    vacString.StatusView = "ČEKA";
                        break;
                }
            int cmp = DateTime.Compare(endDate.ToDateTime(TimeOnly.Parse("00:00 AM")), DateTime.Now);
            if (cmp < 0)
            {
                vacString.Status = HealthcareMD_.VacationStatus.passed;
            }


            return vacString;
        }


    }
}
