using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;

using System.ComponentModel.DataAnnotations;

namespace DtrModel.Entities
{
    public class Project
    {
        
        [Autoincrement]
        public int ProjectID { get; set;  }

        public string ProjectName { get; set;  }

        public bool Active { get; set; }

    }
}
