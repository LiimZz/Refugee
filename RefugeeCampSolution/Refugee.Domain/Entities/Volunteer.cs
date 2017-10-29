//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Refugee.Domain.Entities
//{
//    public class Volunteer
//    {
//        public string VolID { get; set; }

//        [Required]
//        [Display(Name = "First Name")]
//        public string FirstName { get; set; }

//        [Required]
//        [Display(Name = "Last Name")]
//        public string LastName { get; set; }

//        [Required]
//        [Display(Name = "Email Address")]
//        public string Email { get; set; }

//        [Required]
//        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
//        public string Phone { get; set; }

//        [Display(Name = "Say Something")]
//        public string comment { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }
//}
