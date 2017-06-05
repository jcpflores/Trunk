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
        public int Id { get; set; }

        [MaxLength(100)]
        public string ClientName { get; set; }

        public string Contract { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ClientContract> ClientContract { get; set; }
 
    }
}
