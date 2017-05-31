using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DtrModel.Entities;
using SQLite.CodeFirst;
using DtrModel.Interface;

namespace DtrModel.Entities
{
    public class WorkLocation : IEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
