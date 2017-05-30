using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;


namespace DtrModel.Entities
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
