using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Partner
    {
        public int PartnerID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<PartnerDocs> PartnerDocs { get; set; }
    }
}
