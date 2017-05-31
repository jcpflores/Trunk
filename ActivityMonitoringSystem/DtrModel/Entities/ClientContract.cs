using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite.CodeFirst;
using DtrModel.Interface;


namespace DtrModel.Entities
{
   public class ClientContract : IEntity
    {
        [Autoincrement]
        public int Id { get; set; }           

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


        [ForeignKey("Clients")]
        public int ClientRefId { get; set; }
        public virtual Client Clients { get; set; }
    }
}
