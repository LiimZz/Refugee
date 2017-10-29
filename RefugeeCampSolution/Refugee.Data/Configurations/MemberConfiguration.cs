using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class MemberConfiguration : EntityTypeConfiguration<Member>
    {
        public MemberConfiguration()
        {
            HasRequired(p => p.admin)
                .WithMany(c => c.members)
                .HasForeignKey(p => p.AdminID)
                .WillCascadeOnDelete(false);
        }
    }
}
