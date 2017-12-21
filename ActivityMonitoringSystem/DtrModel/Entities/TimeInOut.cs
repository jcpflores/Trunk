using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtrModel.Entities
{
    public class TimeInOut : IEntity
    {
        public int Id { get; set; }
        public string DateTimeIn { get; set; }
        public string DateTimeOut { get; set; }
        public string WorkHours { get; set; }
        public string WorkLocation { get; set; }
        public string Client { get; set; }
        public string TimeOffReason { get; set; }
        public string BillableWorkHours { get; set; }
        public string TimeInSchedule { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }
        public int LatePerMinute { get; set; }
        

        [ForeignKey("DailyTimeRecord")]
        public int DailyTimeRecordRefId { get; set; }

        public DailyTimeRecord DailyTimeRecord { get; set; }
    }
}
