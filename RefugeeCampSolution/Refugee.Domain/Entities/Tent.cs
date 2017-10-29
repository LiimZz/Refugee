using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Tent
    {
        [Key]
        public int TentID { get; set; }
        public string Type { get; set; }
        public int Taille { get; set; }
        public string Img { get; set; }
        public int? CampID { get; set; }
        //prop nav
        public virtual Camp camp { get; set; }
        public virtual ICollection<Equipment> Equipements { get; set; }
        public virtual ICollection<Refug> Refugees { get; set; }
    }
}
