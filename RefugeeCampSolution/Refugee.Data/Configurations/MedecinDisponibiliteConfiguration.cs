using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class MedecinDisponibiliteConfiguration : EntityTypeConfiguration<MedecinDisponibilite>
    {
        public MedecinDisponibiliteConfiguration()
        {
            HasRequired(p => p.MedicalCare)
               .WithMany(c => c.MedecinDispo)
               .HasForeignKey(p => p.MedicalCareID)
               .WillCascadeOnDelete(false);
        }
    }
}
