using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD_.Repository;

namespace HealthcareMD_.Service
{
    public class IngredientService
    {
        private IngredientRepository ingredientRepository;
        public IngredientService(IngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public ObservableCollection<string> GetAll() { 
            return ingredientRepository.GetAll();
        }
    }
}
