using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOperation.Data.Configurations
{
    public class OperationConfigurations: EntityTypeConfiguration<Operation>
    {
        public OperationConfigurations()
        {

            ToTable("Operation");
            HasKey(c => c.OperationId);
            Property(c => c.DateDebut).IsRequired();
            Property(c => c.DateFin).IsRequired();
            Property(c => c.Duree).IsOptional();          

            HasRequired(p => p.Patient)   
                .WithMany(c => c.Operation)
                .HasForeignKey(p => p.PatientId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Personnels)
            .WithMany(v => v.Operations)
            .Map(m =>
            {
                m.ToTable("Membre");   
                m.MapLeftKey("Operation");
                m.MapRightKey("Personnel");
            });

        }

       
    }
}
