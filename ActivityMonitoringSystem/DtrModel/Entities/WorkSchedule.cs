using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;

namespace DtrModel.Entities
{
    public class WorkSchedule : IEntity
    {
        public int Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan TimeOut { get; set; }

        public bool Offset { get; set; }

        public bool Flexi { get; set; } 



    }
}
