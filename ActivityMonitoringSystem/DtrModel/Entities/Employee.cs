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

        [ForeignKey("Clients")]
        public int ClientRefId { get; set; }
        public virtual Client Clients { get; set; }

        [ForeignKey("TechnicalRole")]
        public int TechRoleRefId { get; set; }
        public virtual TechnicalRole TechnicalRole { get; set; }


        [ForeignKey("AttendanceSummary")]
        public int AttendanceRefId { get; set; }
        public virtual AttendanceSummary AttendanceSummary { get; set; }


        [ForeignKey("ProcessRole")]
        public int ProcessRoleRefId { get; set; }
        public virtual ProcessRole ProcessRole { get; set; }


        [ForeignKey("WorkSched")]
        public int WorkSchedRefId { get; set; }
        public virtual WorkSchedule WorkSched { get; set; }

        [ForeignKey("WorkLoc")]
        public int WorkLocRefId { get; set; }
        public virtual WorkLocation WorkLoc { get; set; }

        [ForeignKey("Skills")]
        public int SkillRefId { get; set; }
        public virtual SkillLevel Skills { get; set; }
    }
}
