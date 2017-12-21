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

        public string ResourceId { get; set; }
        public string ProcessRole { get; set; }
        public string ClientName { get; set; }
        public string ContractRef { get; set; }
        public string Project { get; set; }
        public string WorkLocationDefault { get; set; }
        public string TimeInScheduleDefault { get; set; }
        public string TechnicalRole { get; set; }
        public string Technology { get; set; }
        public string SkillLevel { get; set; }
        public string MonthYear { get; set; }

        public virtual ICollection<TimeInOut> TimeInOut { get; set;}
    }
}
 