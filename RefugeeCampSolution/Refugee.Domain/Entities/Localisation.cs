using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Domain.Entities
{
    public class Localisation
    {
        public string Country { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
