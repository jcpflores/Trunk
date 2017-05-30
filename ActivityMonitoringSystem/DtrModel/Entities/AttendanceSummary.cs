using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DtrModel.Entities;
using DtrModel.Interface;


//namespace SQLiteExample.Entity
namespace DtrModel.Entities
{
    public class AttendanceSummary : IEntity
    {
        public int Id { get; set; }
        public int TotalSl { get; set; }

        public int TotalEl { get; set; }

        public int TotalVl { get; set; }

        public int TotalHd { get; set; }

        public int TotalMaternity { get; set; }

        public int TotalPaternity { get; set; }

        public int TotalMinutesLate { get; set; }

    }
}
