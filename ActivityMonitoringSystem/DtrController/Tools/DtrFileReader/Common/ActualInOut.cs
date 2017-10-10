using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtrController.Tools.DtrFileReader.Common
{
    public class ActualInOut
    {
        
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string WorkHours { get; set; }
        public string WorkLocation { get; set; }
        public string TimeOffReason { get; set; }
        public int BillableWorkHours { get; set; }
        public string Notes { get; set; }

    }
}
