using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class PartnerDocs
    {
        [Key]
        public int DocumentID { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public string DocumentPath { get; set; }
        public int PartnerID { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
