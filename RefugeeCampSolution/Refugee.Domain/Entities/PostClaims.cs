using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class PostClaims
    {
        [Key, Column(Order = 0)]
        public string MemberID { get; set; }
        [Key, Column(Order = 1)]
        public int PostID { get; set; }
        public DateTime DateClaim { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Object")]
        public ClaimObject Objet { get; set; }
        public string Status { get; set; } = "Not Treated yet";

        //prop nav
        public virtual User member { get; set; }
        public virtual Post post { get; set; }
    }
}
