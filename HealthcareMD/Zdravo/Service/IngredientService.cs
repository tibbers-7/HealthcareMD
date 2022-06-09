using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD.Repository;

namespace HealthcareMD.Service
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
