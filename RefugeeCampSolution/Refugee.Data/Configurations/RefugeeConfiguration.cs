using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class RefugeeConfiguration : EntityTypeConfiguration<Refug>
    {
        public RefugeeConfiguration()
        {
            HasRequired(p => p.admin)
                .WithMany(c => c.Refugs)
                .HasForeignKey(p => p.AdminID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Tent)
                .WithMany(c => c.Refugees)
                .HasForeignKey(p => p.TentID)
                .WillCascadeOnDelete(false);
        }
    }
}
