using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DtrModel.Interface;

namespace DtrModel.Entities
{
   public class AuditTrail
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public DateTime DateTime { get; set; }
        public string Module { get; set; }
        public string Actions { get; set; }
        public string Description { get; set; }

    }
}
