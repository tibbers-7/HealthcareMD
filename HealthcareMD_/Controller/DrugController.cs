using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD_.Model;
using HealthcareMD_.Service;

namespace HealthcareMD_.Controller
{
    public class DrugController
    {

        private DrugService service;

        public DrugController(DrugService service)
        {
            this.service = service;
        }

        internal List<Drug> GetValidDrugs()
        {
            return service.GetValidDrugs();
        }

        

        internal List<Drug> GetAllDrugs()
        {
            return service.GetAll();
        }

        internal Drug GetById(int drugId)
        {
            return service.GetById(drugId);
        }

        internal int ChangeStatus(bool isAccepted, int drugId)
        {
            return service.ChangeStatus(isAccepted, drugId);
        }

        internal List<DrugReport> GetAllReports()
        {
            return service.GetAllReports();
        }

        internal void CreateDrugReport(int drugId, string reason)
        {
            service.CreateDrugReport(drugId, reason);
        }

        internal ObservableCollection<Drug> SetAllergies(ObservableCollection<Drug> drugs, Patient patient)
        {
            return service.SetAllergies(drugs, patient);
        }

        internal bool GetAllergenConflicts(int drugId, ObservableCollection<Drug> drugs)
        {
            return service.GetAllergenConflicts(drugId, drugs);
        }

        internal List<string> GetAllDrugNames()
        {
            return service.GetAllDrugNames();
        }

        internal Drug GetByName(string selectedDrug)
        {
            return service.GetByName(selectedDrug);
        }

        public void AddNew(int id, string drugName, Status status, string type, string description, List<string> ingredients, int alternativeDrugId)
        {
            Drug newDrug = new Drug(id, drugName, status, type, description, ingredients, alternativeDrugId);
            service.AddNew(newDrug);
        }

        internal void Update(int id, string drugName, Status status, string type, string description, List<string> ingredients, int alternativeDrugId)
        {
            Drug newDrug = new Drug(id, drugName, status, type, description, ingredients, alternativeDrugId);
            service.Update(newDrug);
        }

        internal void DeleteReport(int reportId)
        {
            service.DeleteReport(reportId);
        }
    }
}
