using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtrCommon
{
    public class DtrInOut
    {
        public int Id { get; set; }
        public string DateTimeIn { get; set; }
        public string DateTimeOut { get; set; }
        public string WorkHours { get; set; }
        public string WorkLocation { get; set; }
        public string Client { get; set; }
        public string TimeOffReason { get; set; }
        public int BillableWorkHours { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }

        [ForeignKey("DtrInfo")]
        public virtual int DtrInfoRefId { get; set; }

        public virtual DtrInfo DtrInfo { get; set; }
    }
}
