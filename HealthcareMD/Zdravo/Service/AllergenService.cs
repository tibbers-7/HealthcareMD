using Model;
using Controller;
using System.Collections.ObjectModel;
using Repository;

namespace Service
{
    public class AllergenService
    {
        private AllergenRepository repo;
        public AllergenService(AllergenRepository allergenRepository )
        {
            this.repo = allergenRepository;
        }
        public ObservableCollection<Allergen> GetAllergensByPatient(Patient p)
        {
            ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>();
            ObservableCollection<Allergen> sameAllergens = new ObservableCollection<Allergen>();
            allergens = repo.getAllAllergens();
            sameAllergens = allergens;
            sameAllergens.Add(new Allergen(1, "a", "b"));
            return sameAllergens;
        }
    }
}
