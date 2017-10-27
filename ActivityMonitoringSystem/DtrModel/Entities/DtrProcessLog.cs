using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrModel.Interface;

namespace DtrModel.Entities
{
   public class DtrProcessLog : IEntity
    {

        public int Id { get; set; }
        public string ResourceId { get; set; }
        public string EmpName { get; set; }
        public string Filename { get; set; }
        public DateTime DateProcess { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
        public bool Approve { get; set; }
        

    }
}
