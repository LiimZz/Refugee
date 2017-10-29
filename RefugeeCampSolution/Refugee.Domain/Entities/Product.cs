using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProdID { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int rating { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        //prop nav
        public virtual ICollection<Order> orders { get; set; }
    }
}
