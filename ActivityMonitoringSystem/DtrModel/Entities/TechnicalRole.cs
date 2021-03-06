﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtrModel.Entities
{
    public class TechnicalRole : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string TechRole { get; set; }

        public bool Active { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeRefId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
