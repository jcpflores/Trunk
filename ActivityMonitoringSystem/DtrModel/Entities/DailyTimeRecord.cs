using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;
using DtrModel.Interface;

namespace DtrModel.Entities
{
    public class DailyTimeRecord : IEntity
    {
        public int Id { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public DateTime TimeInSchedule { get; set; }

        public string TimeOffSchedule { get; set; }

        [MaxLength(255)]
        public string Notes { get; set; }
        public int Late { get; set; }
        public int Overtime { get; set; }
        public string Email { get; set; }

        [ForeignKey("AttendanceSummary")]
        public int AttendanceRefId { get; set; }
        public virtual AttendanceSummary AttendanceSummary { get; set; }
    }
}
