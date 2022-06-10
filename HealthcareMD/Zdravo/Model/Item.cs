using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.Model
{
    public class Item
    {
        private string label;
        public string Label { get { return label; } set { label = value; } }
        private int value;
        public int Value { get { return value; } set { value = value; } }
    }
}
