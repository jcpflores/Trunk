using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;
using SQLiteExample.Entity;

namespace SQLiteExample.Entity
{
    class TimeoffReason : IEntity
    {
        public int id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
