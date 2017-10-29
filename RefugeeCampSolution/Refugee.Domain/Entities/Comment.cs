using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Comment
    {
        [Key, Column(Order = 0)]
        public DateTime DateComment { get; set; }
        [Key, Column(Order = 1)]
        public int? PostID { get; set; }
        [Key, Column(Order = 2)]
        public string MemberID { get; set; }
        public string Content { get; set; }
        //Prop nav
        public virtual User member { get; set; }
        public virtual Post post { get; set; }
        //public virtual ICollection<CommentClaim> CommentClaims { get; set; }
    }
}
