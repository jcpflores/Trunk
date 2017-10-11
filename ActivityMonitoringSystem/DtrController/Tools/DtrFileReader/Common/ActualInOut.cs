using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtrController.Tools.DtrFileReader.Common
{
    public class ActualInOut
    {
        
        public string DateTimeIn { get; set; }
        public string DateTimeOut { get; set; }       
        public string WorkHours { get; set; }
        public string WorkLocation { get; set; }
        public string TimeOffReason { get; set; }
        public int BillableWorkHours { get; set; }
        public string Notes { get; set; }

    }
}
