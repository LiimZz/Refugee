using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Refugee.Models
{
    public class CommentViewModels
    {
        public DateTime DateComment { get; set; }
        public int PostID { get; set; }
        public string MemberID { get; set; }
        public string Content { get; set; }
        //Prop nav
        public virtual User member { get; set; }
        public virtual Post post { get; set; }
    }
}