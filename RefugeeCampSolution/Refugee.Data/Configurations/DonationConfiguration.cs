using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class DonationConfiguration : EntityTypeConfiguration<Donations>
    {
        public DonationConfiguration()
        {
            HasRequired(p => p.user)
                .WithMany(c => c.Donations)
                .HasForeignKey(p => p.MemberID)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.camp)
                .WithMany(c => c.Donations)
                .HasForeignKey(p => p.CampID)
                .WillCascadeOnDelete(false);
        }
    }
}
