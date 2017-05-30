﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;
using SQLiteExample.Entity;

namespace SQLiteExample.Entity
{
    public class SkillLevel 
    {
        [Key]
        public int SkillID { get; set; }

        [MaxLength(200)]
        public string SkillName { get; set; }

        public bool Active { get; set; }
    }
}