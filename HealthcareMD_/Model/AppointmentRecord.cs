using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppointmentRecord
    {
        private int id;
        public int Id => id;

        private string patientName;
        public string PatientName => patientName;
        public string PatientInfo => patientName + " " + patientLastName;
        public string DoctorInfo => doctorName + " " + doctorLastName;
        private string patientLastName;
        public string PatientLastName => patientLastName;

        private string doctorName;
        public string DoctorName => doctorName; 

        private string doctorLastName;
        public string DoctorLastName => doctorLastName;

        private string doctorSpecialization;
        public string DoctorSpecialization => doctorSpecialization;
        private string jmbg;
        public string Jmbg => jmbg;
        private DateOnly date;
        public DateOnly Date => date;

        private TimeOnly time;
        public TimeOnly Time => time;

        public AppointmentRecord(int id,string pname,string plname,string dname,string dlname,string dspec,DateOnly date,TimeOnly time,string jmbg)
        {
            this.id = id;
            this.patientName= pname;
            this.patientLastName = plname;
            this.doctorName = dname;
            this.doctorLastName = dlname;
            this.doctorSpecialization = dspec;
            this.date = date;
            this.time = time;
            this.jmbg = jmbg;
        }
    }
}
