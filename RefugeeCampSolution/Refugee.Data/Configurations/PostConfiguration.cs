using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Configurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasRequired(p => p.member)
                .WithMany(c => c.Postss)
                .HasForeignKey(p => p.MemberID)
                .WillCascadeOnDelete(false);

            //HasMany(p => p.Members)
            //.WithMany(v => v.Posts)
            //.Map(m =>
            //{
            //    m.ToTable("PostClaims");
            //    m.MapLeftKey("Post");
            //    m.MapRightKey("Member");
            //});
        }
    }
}
