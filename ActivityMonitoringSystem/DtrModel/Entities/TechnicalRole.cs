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
    public class TechnicalRole 
    {
        [Key]
        public int TechRoleID { get; set; }

        [MaxLength(200)]
        public string TechRole { get; set; }

        public bool Active { get; set; }

    }
}
