using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Courses>
    {
        public CourseConfiguration()
        {
            HasRequired(p => p.admin)
                .WithMany(c => c.Courses)
                .HasForeignKey(p => p.AdminID)
                .WillCascadeOnDelete(false);
        }
    }
}
