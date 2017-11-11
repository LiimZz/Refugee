using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Partner
    {
        [Key]
        public int PartnerID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public virtual ICollection<PartnerDocs> PartnerDocs { get; set; }
    }
}
