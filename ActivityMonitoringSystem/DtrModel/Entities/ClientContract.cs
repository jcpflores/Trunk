using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.CodeFirst;
using SQLiteExample.Entity;


namespace SQLiteExample.Entity
{
   public class ClientContract
    {
        [Autoincrement]
        public int id { get; set; }

        [MaxLength(100)]
        public string ClientName { get; set; }

        [MaxLength(100)]
        public string ContractReference { get; set; }

        public DateTime WorkTimeIn { get; set; }

        public DateTime WorkTimeOut { get; set; }

        public bool Flexi { get; set; }

        public bool Mon { get; set; }

        public bool Tue { get; set; }
        public bool Wed { get; set; }

        public bool Thu { get; set; }

        public bool Fri { get; set; }

        public bool Sat { get; set; }

        public bool Sun { get; set; }

        public bool Active { get; set; }
            
        
        //public Nullable <int> ProjectID { get; set; }

        //[ForeignKey("ProjectID")]        
        //public virtual Project Proj { get; set; }
    }
}
