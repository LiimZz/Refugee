using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Refug
    {
        [Key]
        public int RefugID { get; set; }
        [Required]
        public string AdminID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public AgeStruct Age { get; set; }
        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
        public CivilStatus Staus { get; set; }
        public int TentID { get; set; }

        //prop nav
        public virtual Tent Tent { get; set; }
        public virtual User admin { get; set; }
    }
}
