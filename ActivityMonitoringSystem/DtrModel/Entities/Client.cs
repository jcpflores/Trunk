using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using DtrModel.Interface;

namespace DtrModel.Entities
{
   public  class Client : IEntity
    {
        public int Id { get; set; }

        public virtual ICollection<ClientContract> Contract { get; set; }
        
        public bool Active { get; set; }
    }
}
