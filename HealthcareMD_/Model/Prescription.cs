using HealthcareMD_.Repository;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Model
{
    public class Prescription
    {
        private int id;

        public int Id { get { return id; } set { id = value; } }
        private int patientId;
        public int PatientId { get { return patientId; } set { patientId = value; } }
        private int drugId;

        public int DrugId { get { return drugId; } set { drugId = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }



        internal void FromCSV(GroupCollection csvValues)
        {
            id=int.Parse(csvValues[1].Value);
            patientId = int.Parse(csvValues[2].Value);
            drugId = int.Parse(csvValues[3].Value);
            date = DateOnly.FromDateTime(DateTime.Parse(csvValues[4].Value));
        }

        internal string ToCSV()
        {
            return "#"+id.ToString()+"#" + patientId.ToString() + "#" + drugId.ToString() + "#" + date.ToString();
        }

        internal List<string> GetPrescriptionInfo(string drugName,int count)
        {
            List<string> prescInfo = new List<string>();
            prescInfo.Add(count + ". " + date.ToString("dd/MM/yyyy"));
            prescInfo.Add("\tLEK : " + drugName);
            return prescInfo;
        }
    }

    
}
