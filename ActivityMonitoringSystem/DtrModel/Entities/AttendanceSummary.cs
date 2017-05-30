using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample.Entity
{
    class AttendanceSummary
    {
        public int DTRID { get; set; }
        public int TotalSL { get; set; }

        public int TotalEL { get; set; }

        public int TotalVL { get; set; }

        public int TotalHD { get; set; }

        public int TotalMaterinity { get; set; }

        public int TotalPaternity { get; set; }

        public int TotalMinutesLate { get; set; }


    }
}
