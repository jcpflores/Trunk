using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteExample.Entity;
using SQLite.CodeFirst;

namespace SQLiteExample.Entity
{
   public  class Client : IEntity
    {
        public int id { get; set; }

        public virtual ICollection<ClientContract> Contract { get; set; }

        
        public bool Active { get; set; }
    }
}
