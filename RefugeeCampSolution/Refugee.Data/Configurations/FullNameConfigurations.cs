using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOperation.Data.Configurations
{
    public class FullNameConfigurations: ComplexTypeConfiguration<FullName>
    {
        public FullNameConfigurations()
        {
            Property(p => p.Nom).IsRequired()
                .HasMaxLength(30);
            Property(p => p.Prenom).HasMaxLength(30)
                .IsRequired();
        }
    }
}
