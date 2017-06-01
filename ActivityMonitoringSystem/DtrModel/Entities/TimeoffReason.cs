using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.CodeFirst;
using DtrModel.Interface;

namespace DtrModel.Entities
{
    class TimeoffReason : IEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public bool Active { get; set; }

        [ForeignKey("DailyTimeRecord")]
        public int DailyTimeRecordRefId { get; set; }
        //public virtual DailyTimeRecord DailyTimeRecord { get; set; }

    }
}
