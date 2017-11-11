using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Order
    {
        [Key, Column(Order = 0)]
        public string MemberID { get; set; }
        [Key, Column(Order = 1)]
        public int? ProdID { get; set; }
        [Key, Column(Order = 2)]
        public DateTime PurchaseDate { get; set; }
        public int Qtt { get; set; }
        public virtual User member { get; set; }
        public virtual Product product { get; set; }
    }
}
