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
//using SQLiteExample.Entity;


namespace DtrModel.Entities
{
    public class Employee : IEntity
    {
       [Autoincrement]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string name { get; set; }

        [MaxLength(10)]
        public string Initial { get; set; }

        [Required]
        public bool gender { get; set; }

        [Required]
        public int sickleave { get; set; }

        [Required]
        public int vacationleave { get; set; }

        [Required]
        public int maternityleave { get; set; }

        [Required]
        public int paternityleave { get; set; }

        //public virtual ICollection<ProcessRole> Role { get; set; }


        public Nullable <int> ProjectID { get; set; }       
        public Nullable <int> RoleID { get; set; }                
        public Nullable <int> TechRoleID { get; set; }  
        public Nullable <int> SkillID { get; set; }

        public Nullable <int> WorkScheduleID { get; set; }

        public Nullable <int> DTRID { get; set; }

        public Nullable <int> WorkLocId { get; set; }

        [ForeignKey("ProjectID")]           
        public virtual Project Proj { get; set; }

        [ForeignKey("RoleID")]
        public virtual ProcessRole ProcessRole { get; set; }

        [ForeignKey("TechRoleID")]
        public virtual TechnicalRole TechnicalRole { get; set; }

        [ForeignKey("SkillID")]
        public virtual SkillLevel SkillLevel { get; set; }

        [ForeignKey("Id")]
        public virtual WorkSchedule WorkSchedule { get; set; }

        [ForeignKey("DTRID")]
        public virtual AttendanceSummary AttendanceSummary { get; set; }

        [ForeignKey("Id")]
        public virtual WorkLocation WorkLoc { get; set; }
    }
}
