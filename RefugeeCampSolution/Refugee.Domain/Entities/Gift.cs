using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Gift
    {
        public int GiftID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string AdminID { get; set; }

        //prop nav
        public virtual User Admin { get; set; }
    }
}
