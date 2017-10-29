using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class LocalisationConfiguration : ComplexTypeConfiguration<Localisation>
    {
        public LocalisationConfiguration()
        {
            Property(p => p.ZipCode).IsRequired().HasMaxLength(4);
            Property(p => p.Street).IsRequired();
            Property(p => p.Latitude).IsOptional();
            Property(p => p.Longitude).IsOptional();
            Property(p => p.Country).IsRequired();
        }
    }
}
