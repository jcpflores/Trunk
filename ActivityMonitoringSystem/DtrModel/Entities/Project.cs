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
    public class Project
    {
        
        [Autoincrement]
        public int ProjectID { get; set;  }

        public string ProjectName { get; set;  }

        public bool Active { get; set; }

    }
}
