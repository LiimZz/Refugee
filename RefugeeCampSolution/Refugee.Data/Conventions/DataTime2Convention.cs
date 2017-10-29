using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Conventions
{
    public class DataTime2Convention : Convention
    {
        public DataTime2Convention()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

        }
    }
}
