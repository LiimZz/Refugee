using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
   public class Event
    {
        [Key]
        public int EventID { get; set; }
        public string EventImg { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public Localisation EventLocal { get; set; }
        public string EventType { get; set; }
        public  DateTime EventDateD { get; set; }//Date début
        public DateTime EventDateF { get; set; }// Date fin
        public int EventRating { get; set; }

        public virtual ICollection<Participation> Participations { get; set; }
    }
}
