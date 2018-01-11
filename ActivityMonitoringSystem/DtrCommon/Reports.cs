using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtrCommon
{
    public class Reports
    {
        public string PartnerName { get; set; }
        public string Initial { get; set; }
        public string MonthYear { get; set; }
        public double LatePerMinute { get; set; }
        public double LatePerHour { get; set; }

        public int TardinessFrequency { get; set; }

        public int TotalLeave { get; set; }

        public int SickLeave { get; set; }

        public int VacationLeave { get; set; }

        public int EmergencyLeave { get; set; }

        public int Halfday { get; set; }

        public int ParentalLeave { get; set; }


    }
}
