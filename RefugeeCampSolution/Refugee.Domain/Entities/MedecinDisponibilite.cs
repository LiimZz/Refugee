using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class MedecinDisponibilite
    {
        [Key]
        public int DispoID { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int MedecinID { get; set; }
        //nav prop
        public virtual MedicalCare medecin { get; set; }
    }
}
