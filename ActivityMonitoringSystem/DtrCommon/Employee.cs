using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DtrCommon
{
  //  public enum Gender { Male =1  , Female =0 }

    public class Employee
    { 
     
        public int Id { get; set; }
        public string Name { get; set; }


        public string Initial { get; set; }

        public string ResourceId { get; set; }

        public string EmpNo { get; set; }


        public string Email { get; set; }

        public string ProcessRole { get; set; }

        public string TecnicalRole { get; set; }

        public string Technology { get; set; }

        public string SkillLevel { get; set; }

        public string Client { get; set; }

        public string Contract { get; set; }

        public string Project { get; set; }

        public string WorkLocation { get; set; }

       public bool Gender { get; set; }
      // public Gender Gender { get; set; }

        public int SickLeave { get; set; }


        public int VacationLeave { get; set; }


        public int MaternityLeave { get; set; }


        public int PaternityLeave { get; set; }

      
    }
}
