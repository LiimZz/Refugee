using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
   public class Camp
    {
        [Key]
        public int CampID { get; set; }
        public Localisation Localisation { get; set; }
        public string CampName { get; set; }
        public int Size { get; set; }
        //prop nav
        public virtual ICollection<Tent> Tents { get; set; }
        public virtual ICollection<Donations> Donations { get; set; }
    }
}
