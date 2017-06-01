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
       

        // Get File to read
        string getDtrFilePath { get; set; }
        string Sheet { get; set; }

        

        DateTime Date { get; set; }
        DateTime TimeIn { get; set; }
        DateTime TimeOut { get; set; }
        String ProcessRole { get; set; }
        String ClientName { get; set; }
        String Contact { get; set; }
        String Project { get; set; }
        String WorkLocation { get; set; }
        String TimeInSchedule { get; set; }
        String Notes { get; set; }
        String Late { get; set; }
        String Overtime { get; set; }
        String Undertime { get; set; }
          

    }
}
