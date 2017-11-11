using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class JobOffer
    {
        [Key, Column(Order = 0)]
        public int RefugID { get; set; }
        [Key, Column(Order = 1)]
        public int PartnerID { get; set; }
        public string Post { get; set; }
        public double Salary { get; set; }
        //Prop nav
        public virtual Refug refuge { get; set; }
        public virtual Partner partner { get; set; }
    }
}
