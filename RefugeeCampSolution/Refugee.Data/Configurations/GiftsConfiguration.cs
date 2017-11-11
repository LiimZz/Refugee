using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class GiftsConfiguration : EntityTypeConfiguration<Gift>
    {
        public GiftsConfiguration()
        {
            HasRequired(p => p.Admin)
                .WithMany(c => c.Gifts)
                .HasForeignKey(p => p.AdminID)
                .WillCascadeOnDelete(false);
        }
    }
}
