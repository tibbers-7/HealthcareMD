using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Allergen
    {
        private string name;
        public string Name => name;

        private int id;
        public int Id => id;

        private string description;
        public string Description => description;

        public Allergen(int id,string name,string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
    }
}
