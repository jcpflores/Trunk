using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using SQLiteExample.Entity;
using System.ComponentModel.DataAnnotations;

namespace SQLiteExample.Entity
{
    class ClientHoliday
    {
        public int id { get; set; }
        public DateTime HolidayDate { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
