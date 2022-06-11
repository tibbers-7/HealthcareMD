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
        private int appointmentCount;
        public int AppointmentCount { get { return appointmentCount; } set { appointmentCount = value; } }

    }
}
