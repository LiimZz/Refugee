using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class MedicalCare
    {
        [Key]
        public int MedecinID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Field")]
        public string Field { get; set; }

        //prop nav
        public virtual ICollection<Consultation> Consultations { get; set; }
        public virtual ICollection<MedecinDisponibilite> MedecinDispo { get; set; }
    }
}
