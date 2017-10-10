﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrController.Tools.DtrFileReader;


namespace DtrController.Tools.DtrFileReader.Common
{
    public class DtrFileModel
    {
        public DtrFileModel()
        { }

        public string ResourceId { get; set; }
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string ProcessRole { get; set; }
        public string ClientName { get; set; }
        public string ContractRef { get; set; }
        public string Project { get; set; }
        public string WorkLocation { get; set; }
        public DateTime TimeInSchedule { get; set; }
        public string Notes { get; set; }
        public string TimeOffReason { get; set; }
        public int Late { get; set; }
        public int Overtime { get; set; }
        public string Undertime { get; set; }
        public Nullable<int> WorkingHours { get; set; }   
        public string TechnicalRole { get; set; }
        public string Technology { get; set; }
        public string SkillLevel { get; set; }            

        public ICollection<ActualInOut> ActualInOut { get; set; }
    }
}
