using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DtrModel.Interface;
using System.ComponentModel.DataAnnotations.Schema;

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

       
        [ForeignKey("Employee")]
        public int EmployeeRefId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
