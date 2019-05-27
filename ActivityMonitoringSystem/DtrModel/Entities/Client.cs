using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtrModel.Entities
{
   public class Client : IEntity
    {
        [Autoincrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string ClientName { get; set; }

        public string Contract { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }
        public bool Flexi { get; set; }
        public bool Active { get; set; }



        //public virtual ICollection<ClientContract> ClientContract { get; set; }
        //[ForeignKey("Employee")]
        //public int EmployeeRefId { get; set; }
        //public virtual Employee Employee { get; set; }
    }
}
