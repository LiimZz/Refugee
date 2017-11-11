using Newtonsoft.Json;
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
        [JsonIgnore]
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
        [JsonIgnore]
        public int TentID { get; set; }

        //jee needs
        public string Skills { get; set; }
        public string HealthStatus { get; set; }

        //prop nav
        [JsonIgnore]
        public virtual Tent Tent { get; set; }
        [JsonIgnore]
        public virtual User admin { get; set; }
        [JsonIgnore]
        public virtual ICollection<Consultation> Consultations { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }

    }
}
