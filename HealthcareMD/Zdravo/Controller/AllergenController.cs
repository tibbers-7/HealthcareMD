using Model;
using System.Collections.ObjectModel;
using Repository;

namespace Controller
{
    public class AllergenController
    {
        private AllergenRepository repository;

        public AllergenController()
        {
            repository = new AllergenRepository();
        }
        public ObservableCollection<Allergen> GetAllergensByPatient(Patient p)
        {
            ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>();
            ObservableCollection<Allergen> sameAllergens= new ObservableCollection<Allergen>();
            allergens = repository.getAllAllergens();
            foreach (Allergen allergen in allergens)
                //  {
                //      foreach(Allergen patientAllergen in p.Allergens)
                //     {
                /////        if (allergen.Id == patientAllergen.Id) sameAllergens.Add(allergen);
                //    }
                //  }
                sameAllergens = allergens;
            sameAllergens.Add(new Allergen(1, "a", "b"));
            return sameAllergens;
        }
    }
}
