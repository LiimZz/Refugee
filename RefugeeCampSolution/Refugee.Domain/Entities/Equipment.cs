using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Equipment
    {
        [Key]
        public int EquipID { get; set; }
        public string Name { get; set; }
        public double Qtt { get; set; }
        public TypeEquipment Type { get; set; }
        public string Img { get; set; }
        public int? TentID { get; set; }
        //prop nav
        public virtual Tent tent { get; set; }
    }
}
