using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DtrModel.Interface;

namespace DtrModel.Entities
{
   public class ProcessRole : IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string RoleName { get; set; }

        [Required]
        public bool Active { get; set; }

        //public  ICollection<Employee> Employee { get; set; }
    }
}
