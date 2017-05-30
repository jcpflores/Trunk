using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;

namespace DtrModel.Entities
{
    public class Users
    {
        public int id { get; set; }

        [MaxLength(25)]
        public string Username { get; set; }

        [MaxLength(25)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
