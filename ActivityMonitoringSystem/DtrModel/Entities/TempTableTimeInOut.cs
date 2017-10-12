﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations;

namespace DtrModel.Entities
{
    public class TempTableTimeInOut : IEntity
    {
        public int Id { get; set; }
        public string DateTimeIn { get; set; }
        public string DateTimeOut { get; set; }
        public string WorkHours { get; set; }
        public string WorkLocation { get; set; }
        public string TimeOffReason { get; set; }
        public int BillableWorkHours { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }
    }
}