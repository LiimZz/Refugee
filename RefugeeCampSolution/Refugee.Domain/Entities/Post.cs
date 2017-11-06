using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string MemberID { get; set; }
        public DateTime DatePub { get; set; }
        public string Picture { get; set; }
        public String Content { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

        //prop nav
        public virtual User member { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostClaims> PostClms { get; set; }
    }
}
