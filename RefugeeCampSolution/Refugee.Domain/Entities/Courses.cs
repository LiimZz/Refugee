using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Courses
    {   
        [Key]
        public int CourseID { get; set; }
        public string AdminID { get; set; }
        public DateTime DateCourse { get; set; }
        public string Matiere { get; set; }
        public int NbrPlaceDispo { get; set; }
        public string ZoneAge { get; set; }
        //prop nav
        public virtual User admin { get; set; }
    }
}
