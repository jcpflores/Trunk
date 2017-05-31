using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using DtrModel.Entities;
using DtrModel.Interface;

namespace DtrModel.Entities
{
    public class Holiday : IEntity
    {
        public int Id { get; set; }

        public DateTime HolidayDate { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
