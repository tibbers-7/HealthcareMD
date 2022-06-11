using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Model
{
    public class Drug
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string type;
        public string Type { get { return type; } set { type = value; } }
        private HealthcareMD_.Status status;
        public HealthcareMD_.Status Status { get { return status; } set { status = value;} }
        private string description;
        public string Description { get { return description; } set { description = value; } }
        private bool isAllergic;
        public bool IsAllergic { get { return isAllergic; } set { isAllergic = value; } }
        private int alternativeDrugId;
        public int AlternativeDrugId { get { return alternativeDrugId; } set { alternativeDrugId = value; } }
        public List<string> AllergenConflicts;
        public string StatusString
        {
            get {
                string retVal;
                switch (status)
                {
                    case (HealthcareMD_.Status.accepted):
                        retVal = "ODOBRENO";
                        break;
                    case (HealthcareMD_.Status.denied):
                        retVal = "ODBIJENO";
                        break;
                    case (HealthcareMD_.Status.reported):
                        retVal = "PRIJAVLJENO";
                        break;
                    default:
                        retVal = "NA ČEKANJU";
                        break;

                }
                return retVal;
            
            }
        }
        private List<string> ingredients;
        public List<string> Ingredients { get { return ingredients; } set { ingredients = value; } }

        public Drug(int id, string name, HealthcareMD_.Status status, string type, string description, List<string> ingredients, int alternativeDrugId)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.type = type;
            this.description = description;
            this.ingredients = ingredients;
            this.alternativeDrugId = alternativeDrugId;
        }

        public Drug()
        {
            ingredients=new List<string>();
        }

        internal void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            name = csvValues[2].Value;
            type = csvValues[3].Value;
            switch (csvValues[4].Value)
            {
                case "A":
                    status = HealthcareMD_.Status.accepted;
                    break;
                case "D":
                    status = HealthcareMD_.Status.denied;
                    break;
                case "R":
                    status=HealthcareMD_.Status.reported;
                    break;
                default:
                    status = HealthcareMD_.Status.waiting;
                    break;
            }
            string ingredientsAll = csvValues[5].Value;
            string[] ingredientsStrings= ingredientsAll.Split(';');
            foreach(string ingredient in ingredientsStrings)
            {
                ingredients.Add(ingredient);
            }
            description=csvValues[6].Value;
            alternativeDrugId = int.Parse(csvValues[7].Value);
        }

        internal string ToCSV()
        {
            char statusChar;
            switch (status)
            {
                case HealthcareMD_.Status.accepted:
                    statusChar = 'A';
                    break;
                case HealthcareMD_.Status.denied:
                    statusChar = 'D';
                    break;
                case HealthcareMD_.Status.reported:
                    statusChar = 'R';
                    break;
                default:
                    statusChar = 'W';
                    break;

            }
            string ingredientsString = "";
            foreach (string ingredient in ingredients)
            {
                if (ingredient != null)
                {
                    ingredientsString = ingredientsString + ingredient + ";";
                }

            }
            string res = "#" + id.ToString() + "#" + name+ "#" + type + "#" + statusChar + "#"+ingredientsString+"#"+description;
            
            return res;

        }


    }
}
