using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Refugee.Models
{
    public class PostViewModels
    {
        [Key]
        public int PostID { get; set; }
        public string MemberID { get; set; }
        public DateTime DatePub { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }
        public String Content { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }

        //prop nav
        public virtual User member { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Members { get; set; }
        public virtual ICollection<PostClaims> PostClms { get; set; }
    }
}