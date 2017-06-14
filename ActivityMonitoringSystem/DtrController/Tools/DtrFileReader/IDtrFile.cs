using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrController.Tools.DtrFileReader.Common;

namespace DtrController.Tools.DtrFileReader
{
    public interface IDtrFile 
    {

        void SetController(DtrFileReader controller);
        // Get File to read
        string getDtrFilePath { get; set; }
        string Sheet { get; set; }
        bool Status { get; set; }

        

        DateTime DateIn { get; set; }
        DateTime DateOut { get; set; }
        string TimeIn { get; set; }
        string TimeOut { get; set; }
        string ProcessRole { get; set; }
        string ClientName { get; set; }
        string Contact { get; set; }
        string Project { get; set; }
        string WorkLocation { get; set; }
        string TimeInSchedule { get; set; }
        string TimeOffReason { get; set; }
        string Notes { get; set; }
        int Late { get; set; }
        int Overtime { get; set; }
        int Undertime { get; set; }
        Nullable<int> WorkingHours { get; set; }
        String ResourceId { get; set; }
    }
}
