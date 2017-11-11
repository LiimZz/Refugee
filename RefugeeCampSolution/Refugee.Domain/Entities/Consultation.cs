using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Consultation
    {
        [Key, Column(Order = 0)]
        public DateTime DateConsultation { get; set; }
        [Key, Column(Order = 1)]
        public int RefugID { get; set; }
        [Key, Column(Order = 2)]
        public int MedecinID { get; set; }
        public string Maladie { get; set; }
        public string Etat { get; set; }
        //Prop nav
        public virtual Refug refuge { get; set; }
        public virtual MedicalCare medecin { get; set; }
    }
}