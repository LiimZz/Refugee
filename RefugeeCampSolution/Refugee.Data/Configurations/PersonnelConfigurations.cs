using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionOperation.Data.Configurations
{
    public class PersonnelConfigurations : EntityTypeConfiguration<Personnel>
    {
        public PersonnelConfigurations()
        {
            
            HasKey(c => c.CodePersonnel);
            Property(c => c.Age).IsRequired();

            Map<Chirurgien>(c =>
            {
                c.Requires("IsChirurgien").HasValue(1);  
            });
            Map<EquipePluridisciplinaire>(c =>
            {
                c.Requires("IsChirurgien").HasValue(0);
            });
        }
    }
}
