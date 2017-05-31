using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtrModel.Entities
{
    public class Project
    {
        
        [Autoincrement]
        public int Id { get; set;  }

        public string ProjectName { get; set;  }
        public bool Active { get; set; }

        [ForeignKey("ClientContract")]
        public int ClientContractRefId { get; set; }
        public virtual ClientContract ClientContract { get; set; }
        

    }
}
