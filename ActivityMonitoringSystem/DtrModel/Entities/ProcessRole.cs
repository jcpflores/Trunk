using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DtrModel.Entities
{
   public class ProcessRole
    {
        [Key]
        public int RoleID { get; set; }

        [MaxLength(200)]
        public string RoleName { get; set; }

        [Required]
        public bool Active { get; set; }

        public  ICollection<Employee> Employee { get; set; }
    }
}
