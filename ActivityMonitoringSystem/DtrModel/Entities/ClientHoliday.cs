﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;

namespace DtrModel.Entities
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
