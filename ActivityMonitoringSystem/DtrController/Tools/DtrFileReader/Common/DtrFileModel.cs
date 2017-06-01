using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrController.Tools.DtrFileReader;

namespace DtrController.Tools.DtrFileReader.Common
{
    public class DtrFileModel : IDtrFile
    {
        public DtrFileModel()
        { }
        public String getDtrFilePath { get; set; }
        public String Sheet { get; set; }

        public DateTime Date { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public String ProcessRole { get; set; }
        public String ClientName { get; set; }
        public String Contact { get; set; }
        public String Project { get; set; }
        public String WorkLocation { get; set; }
        public String TimeInSchedule { get; set; }
        public String Notes { get; set; }
        public String Late { get; set; }
        public String Overtime { get; set; }
        public String Undertime { get; set; }

    }
}
