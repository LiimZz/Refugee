//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Refugee.Domain.Entities
//{
//    public class Member
//    {
//        //ContainerName => cn
//        //DistinguishedName => dn
//        //DomainComponent => dc

//        [Key]
//        public string MemberID { get; set; }
//        public string AdminID { get; set; }
//        public string Name { get; set; }
//        public String _firstName { get; set; } //givenName
//        public String _middleName { get; set; } //initials
//        public String _lastName { get; set; } //sn
//        public String _loginName { get; set; } //userPrincipalName
//        public String _aSMAccountName { get; set; } //aSMAccountName (pre windows 2000)
//        public String _loginNameWithDomain { get; set; }
//        public String _emailAddress { get; set; } //mail
//        public String _streetAddress { get; set; }
//        public String _city { get; set; }
//        public String _postalCode { get; set; } //postalCode
//        public String _country { get; set; }
//        public String _Type { get; set; } //sAMAccountType
//        public Int16 _AccountExpires { get; set; } //_AccountExpires
//        //prop nav
//        public virtual User admin { get; set; }
//        public virtual ICollection<Comment> Comments { get; set; }
//        public virtual ICollection<Post> Posts { get; set; }
//        public virtual ICollection<Post> Postss { get; set; }
//        public virtual ICollection<Order> orders { get; set; }
//        public virtual ICollection<Participation> Participations { get; set; }
//        public virtual ICollection<PostClaims> PostClms { get; set; }
//    }
//}
