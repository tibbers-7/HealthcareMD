using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareMD.FileHandler;

namespace HealthcareMD.Repository
{
    public class IngredientRepository
    {
        private IngredientFileHandler ingredientFileHandler;
        private ObservableCollection<string> ingredients;
        public ObservableCollection<string> Ingredients { get { return ingredients; } set { ingredients = value; } }
        
        public IngredientRepository()
        {
            this.ingredientFileHandler = new IngredientFileHandler();
            this.ingredients = ingredientFileHandler.Read();
        }

        public void Create(string ingredient)
        {
            ingredients.Add(ingredient);
            //ingredientFileHandler.Write(ingredients);
        }

        public ObservableCollection<string> GetAll() {
            ingredients = ingredientFileHandler.Read();
            return ingredients;
        }
    }
}
