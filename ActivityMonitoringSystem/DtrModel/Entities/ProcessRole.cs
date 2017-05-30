﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLiteExample;
using DtrModel.Entities;

namespace DtrModel.Entities
{
   public class ProcessRole
    {
        [Key]
        public int RoleID { get; set; }

        [MaxLength(200)]
        public string RoleName { get; set; }

        [Required]
        public bool Active { get; set; }

        public  ICollection<Employee> Employee { get; set; }
    }
}
