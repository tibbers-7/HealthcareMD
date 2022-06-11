using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthcareMD_.Model
{
    public class DrugReport
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private int drugId;
        public int DrugId { get { return drugId; } set { drugId = value; } }
        private string reason;
        public string Reason { get { return reason; } set { reason = value; } }

        internal void FromCSV(GroupCollection csvValues)
        {
            
            id = int.Parse(csvValues[1].Value);
            drugId = int.Parse(csvValues[2].Value);
            reason = csvValues[3].Value;
        }

        internal string ToCSV()
        {
            string res = "#" + id.ToString() + "#" + drugId.ToString() + "#" + reason;
            return res;

        }
    }
}
