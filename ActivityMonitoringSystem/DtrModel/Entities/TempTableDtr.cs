﻿using SQLite.CodeFirst;
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

        public string ResourceId { get; set; }
        public string ProcessRole { get; set; }
        public string ClientName { get; set; }
        public string ContractRef { get; set; }
        public string Project { get; set; }
        public string WorkLocationDefault { get; set; }
        public DateTime TimeInScheduleDefault { get; set; }
        public string TechnicalRole { get; set; }
        public string Technology { get; set; }
        public string SkillLevel { get; set; }
        public string MonthYear { get; set; }

        public virtual ICollection<TempTableTimeInOut> TempTableTimeInOut { get; set; }
    }
}
