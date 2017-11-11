using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Donations
    {
        public int DonationID { get; set; }
        public string MemberID { get; set; }
        public int? CampID { get; set; }
        public DateTime DateDonation { get; set; }
        public string TypeDonation { get; set; }
        public double Amount { get; set; }
        //prop nav
        //[ForeignKey("Id")]
        public virtual User user { get; set; }
        public virtual Camp camp { get; set; }
    }
}
