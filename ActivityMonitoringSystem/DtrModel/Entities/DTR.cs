using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;
using DtrModel.Interface;

namespace DtrModel.Entities
{
   public class DTR : IEntity
    {
        public int Id { get; set; }

        public DateTime DTRDate { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan TimeOut { get; set; }

       public TimeSpan TimeInSchedule { get; set; }

        public string TimeOffSchedule { get; set; }

        [MaxLength(255)]
        public string Notes { get; set; }

        public int LatePerDay { get; set; }

        public int ExcessPerDay { get; set; }

     
    }
}
