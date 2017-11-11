using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class PartnerConfiguration : EntityTypeConfiguration<PartnerDocs>
    {
        public PartnerConfiguration()
        {
            HasRequired(p => p.Partner)
                .WithMany(c => c.PartnerDocs)
                .HasForeignKey(p => p.PartnerID)
                .WillCascadeOnDelete(false);
        }
    }
}
