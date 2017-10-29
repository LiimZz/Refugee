//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Refugee.Domain.Entities
//{
//    public class CommentClaim
//    {
//        public string Claim_Object { get; set; }
//        public string Claim_Description { get; set; }
//        public DateTime Claim_Date { get; set; }
//        public DateTime Claim_TreatmentDate { get; set; }
//        public string Status { get; set; }

//        [ForeignKey("Comment"), Column(Order = 0)]
//        public DateTime DateComment { get; set; }
//        [ForeignKey("Comment"), Column(Order = 1)]
//        public int? PostID { get; set; }
//        [ForeignKey("Comment"), Column(Order = 2)]
//        public int? MemberID { get; set; }
//        //[ForeignKey("Member"), Column(Order = 3)]
//        //public int? MemberID { get; set; }
//        //public int? CommentID { get; set; } ?????????????????????????????????????????
//        //prop nav
//        public Member member { get; set; }
//        public Post post { get; set; }
//        public Comment comment { get; set; }
//    }
//}
