using System;
using System.Collections.Generic;
using HealthcareMD.FileHandler;
using Model;

namespace HealthcareMD.Repository
{
    public class DrugRepository
    {
        private List<Drug> drugs;
        private readonly DrugFileHandler fileHandler=new DrugFileHandler();
        private int errorCode;

        public DrugRepository()
        {
            InitDrugs();
        }

        private void InitDrugs()
        {
            List<object> drugList=fileHandler.Read();
            drugs = new List<Drug>();
            foreach (object drugObj in drugList)
            {
                Drug drug = (Drug)drugObj;
                drugs.Add(drug);
            }
        }

        public int AddNew(Drug drug)
        {
            List<Drug> list = drugs;
            int listCount = list.Count;
            string[] newLines = new string[listCount + 1];
            for (int i = 0; i < listCount; i++)
            {
                newLines[i] = list[i].ToCSV();
            }
            newLines[listCount] = drug.ToCSV();
            errorCode=fileHandler.Write(newLines);
            InitDrugs();
            return errorCode;
        }

        public int Update(Drug newDrug)
        {
            int listCount = drugs.Count;
            string[] newLines = new string[listCount];
            int i = 0;
            foreach (Drug drug in drugs)
            {
                if (drug.Id != newDrug.Id) newLines[i] = drug.ToCSV();
                else newLines[i] = newDrug.ToCSV();
                i++;
            }
            errorCode=fileHandler.Write(newLines);
            InitDrugs();
            return errorCode;
        }

        public int Delete(Drug newDrug)
        {
            int listCount = drugs.Count;
            string[] newLines = new string[listCount];

            newLines = new string[listCount - 1];
            int i = 0;
            foreach (Drug drug in drugs)
            {
                if (drug.Id != newDrug.Id) newLines[i] = drug.ToCSV();
                i++;
            }

            errorCode=fileHandler.Write(newLines);
            InitDrugs();
            return errorCode;
        }

        internal Drug GetByName(string selectedDrug)
        {
            foreach (Drug drug in drugs)
            {
                if (drug.Name.Equals(selectedDrug)) return drug;
            }
            return null;
        }

        internal List<string> GetAllDrugNames()
        {
            List<string> names = new List<string>();
            foreach (Drug drug in drugs)
            {
                names.Add(drug.Name);
            }
            return names;
        }

        public List<Drug> GetAll()
        {
            return drugs;
        }


        internal Drug GetById(int drugId)
        {
            foreach(Drug drug in drugs)
            {
                if (drug.Id == drugId) return drug;
            }
            return null;
        }

        internal int ChangeStatus(Drug drug)
        {
            return Update(drug);
        }

    }
}
