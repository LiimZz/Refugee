using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Adoption
    {
        [Key, Column(Order = 0)]
        public DateTime DateAdoption { get; set; }
        [Key, Column(Order = 1)]
        public int RefugID { get; set; }
        [Key, Column(Order = 2)]
        public string MemberID { get; set; }
        public string Description { get; set; }
        public string Etat { get; set; }
        //Prop nav
        public virtual Refug refuge { get; set; }
        public virtual User member { get; set; }
    }
}
