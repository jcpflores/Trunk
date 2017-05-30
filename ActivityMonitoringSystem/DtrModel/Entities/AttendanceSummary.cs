using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DtrModel.Entities;


//namespace SQLiteExample.Entity
namespace DtrModel.Entities
{
    public class AttendanceSummary
    {
        public int DTRID { get; set; }
        public int TotalSL { get; set; }

        public int TotalEL { get; set; }

        public int TotalVL { get; set; }

        public int TotalHD { get; set; }

        public int TotalMaterinity { get; set; }

        public int TotalPaternity { get; set; }

        public int TotalMinutesLate { get; set; }

        public int DTRId { get; set; }

        [ForeignKey("Id")]
        public virtual DTR Dtr { get; set; }
    }
}
