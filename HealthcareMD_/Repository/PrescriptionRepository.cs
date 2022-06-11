using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandler;
using Model;
using HealthcareMD_.FileHandler;

namespace Repository
{
    public class PrescriptionRepository
    {
        public List<Prescription> prescriptions;
        private readonly PrescriptionFileHandler fileHandler=new PrescriptionFileHandler();
        private int errorCode;

        public PrescriptionRepository()
        {
            InitPrescriptions();
        }

        private void InitPrescriptions()
        {
            List<object> list = fileHandler.Read();
            prescriptions = new List<Prescription>();
            foreach (object prescObj in list)
            {
                Prescription presc=(Prescription) prescObj;
                prescriptions.Add(presc);
            }
        }
        public int AddNew(Prescription prescription)
        {
            prescription.Id=prescriptions.Last().Id+1;
            int listCount = prescriptions.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = prescriptions[i].ToCSV();
            }
            newLines[listCount] = prescription.ToCSV();
            errorCode=fileHandler.Write(newLines);
            InitPrescriptions();
            return errorCode;
        }

    }
}
