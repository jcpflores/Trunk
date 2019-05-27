using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtrCommon
{
   public  class Client
    {
      
        public int Id { get; set; }


        public string ClientName { get; set; }

        public string Contract { get; set; }

        public string TimeIn { get; set; }

        public string TimeOut { get; set; }

        public bool Flexi { get; set; }
        public bool Active { get; set; }
    }
}
