using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Conversation
    {
        public string UserID { get; set; }
        public string AdminID { get; set; }
        public string msg { get; set; }
    }
}
