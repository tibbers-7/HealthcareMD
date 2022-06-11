using FileHandler;
using Model;
using System.Collections.ObjectModel;

namespace Repository
{
    public class AllergenRepository
    {
        private AllergenFileHandler filehandler;
        
        public AllergenRepository()
        {
            filehandler = new AllergenFileHandler();
        }
        public ObservableCollection<Allergen> getAllAllergens()
        {
            ObservableCollection<Allergen> allergens = new ObservableCollection<Allergen>();
            allergens = filehandler.Load();
            return allergens;
        }
    }
}
