using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Participation
    {
        [Key, Column(Order = 0)]
        public int? EventID { get; set; }
        [Key, Column(Order = 1)]
        public string MemberID { get; set; }
        [Key, Column(Order = 2)]
        public DateTime ParticipationDate { get; set; }
        [Key, Column(Order = 3)]
        public Localisation ParticipationPlace { get; set; }
        //prop nav
        public Event even { get; set; }
        public User member { get; set; }
    }
}
