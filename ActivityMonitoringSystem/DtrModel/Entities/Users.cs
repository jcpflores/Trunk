using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using DtrModel.Interface;

namespace DtrModel.Entities
{
    public class Users : IEntity
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Username { get; set; }

        [MaxLength(25)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
