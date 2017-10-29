using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class AgeStructConfiguration : ComplexTypeConfiguration<AgeStruct>
    {
        public AgeStructConfiguration()
        {
            Property(p => p.Day).IsRequired();
            Property(p => p.Month).IsRequired();
            Property(p => p.Year).IsRequired();
        }
    }
}
