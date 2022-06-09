using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.FileHandler
{
    public class IngredientFileHandler
    {
        private string filePath = "data/ingredients.txt";

        public ObservableCollection<string> Read() {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            ObservableCollection<string> ingredients = new ObservableCollection<string>();
            foreach (var s in lines)
            {
                if (s.Equals("")) break;
                ingredients.Add(s);
            }
            return ingredients;
        }
    }
}
