using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VacationRecord
    {
        private int id;
        public int Id => id;

        private string doctorName;
        public string DoctorName => doctorName;

        private string doctorSpecialization;
        public string DoctorSpecialization => doctorSpecialization;
        
        private string period;
        public string Period => period;

        private string reason;

        public string Reason => reason;

        public VacationRecord(int id,string doctorName,string doctorSpecialization,string period,string reason)
        {
            this.id = id;
            this.doctorName = doctorName;
            this.doctorSpecialization=doctorSpecialization;
            this.period=period;
            this.reason=reason;
        }
    }
}
