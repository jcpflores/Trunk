using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations.Schema;
using DtrModel.Interface;
using DtrModel.Entities;



namespace DtrModel.Entities
{
    public class Employee : IEntity
    {
        [Autoincrement]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Initial { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public int SickLeave { get; set; }

        [Required]
        public int VacationLeave { get; set; }

        [Required]
        public int MaternityLeave { get; set; }

        [Required]
        public int PaternityLeave { get; set; }
      

        public virtual ICollection<AttendanceSummary> AttendanceSummary { get; set; }
        public virtual ICollection<SkillLevel> Skills { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<ProcessRole> ProcessRole { get; set; }
        public virtual ICollection<TechnicalRole> TechnicalRole { get; set; }
        public virtual ICollection<WorkLocation> WorkLocation { get; set; }
        public virtual ICollection<WorkSchedule>  WorkSchedule { get; set; }
    }
}
