using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrModel.Interface;

namespace DtrModel.Entities
{
  public class TempTableDtr : IEntity
    {
        
        public int Id { get; set; }

        public string Contact { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public string TimeInSchedule { get; set; }

        public string TimeOffSchedule { get; set; }

        [MaxLength(255)]
        public string Notes { get; set; }
        public int Late { get; set; }
        public int Overtime { get; set; }
        public string ReferenceId { get; set; }

        public int ProjectId { get; set; }
        public string WorkLocation { get; set; }

        public int ClientId { get; set; }

        public int TimeOffReasonId { get; set; }

        public DateTime DateProcess { get; set; }
    }
}
