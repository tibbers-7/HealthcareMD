using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    internal class ChosenDoctors
    {
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }
        private List<int> chosenDoctorIds;
        public List<int> ChosenDoctorIds { get { return chosenDoctorIds; } set { chosenDoctorIds = value; } }

        public ChosenDoctors()
        {
            chosenDoctorIds = new List<int>();
        }

        public void FromCSV(GroupCollection csvValues)
        {
            patientId = int.Parse(csvValues[1].Value);
            String[] doctorString = csvValues[2].Value.Split(',');
            foreach(string doctor in doctorString)
            {
                chosenDoctorIds.Add(int.Parse(doctor));
            }

        }

        internal string ToCSV()
        {
            //#doctorId#startDate#endDate#accepted
            //#1#2022/01/01#2022/02/02#Y
            string doctors="";
            foreach (int doctor in chosenDoctorIds)
            {
                doctors=doctors+ doctor.ToString() + ";";
            }
            string res = '#' + patientId.ToString() + '#'+doctors;
            return res;
        }


    }
}
