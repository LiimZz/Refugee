using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Product
    {
        public Product()
        {

        }
        public Product(int id, int stock, string name, string image, double price, int rating, int quantity, Category category)
        {
            this.ProdID = id;
            this.Stock = stock;
            this.Name = name;
            this.Image = image;
            this.Price = price;
            this.rating = rating;
            this.quantity = quantity;
            this.Category = category;
        }

        [Key]
        public int ProdID { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        public double Price { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public int rating { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int quantity { get; set; }
        public int CategoryID { get; set; }
        //prop nav
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
