using Model;
using System.Collections.ObjectModel;
using Repository;
using Service;

namespace Controller
{
    public class AllergenController
    {
        private AllergenService service;

        public AllergenController(AllergenService service)
        {
            this.service = service;
        }
        public ObservableCollection<Allergen> GetAllergensByPatient(Patient p)
        {
            return service.GetAllergensByPatient(p);
        }
    }
}
