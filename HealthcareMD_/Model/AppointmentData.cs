using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD_.Model
{
    public class AppointmentData
    {
        private DayOfWeek day;
        public DayOfWeek Day { get { return day; } set { day = value; } }
        public string DaySerbian
        {
            get { switch (day)
                {
                    case DayOfWeek.Sunday: return "Nedelja"; 
                        case DayOfWeek.Monday: return "Ponedeljak";
                        case (DayOfWeek.Tuesday): return "Utorak";
                        case (DayOfWeek.Wednesday): return "Sreda";
                        case (DayOfWeek.Friday): return "Petak";
                        default: return "Subota";
                }
            }
        }
        private int appointmentCount;
        public int AppointmentCount { get { return appointmentCount; } set { appointmentCount = value; } }

    }
}
