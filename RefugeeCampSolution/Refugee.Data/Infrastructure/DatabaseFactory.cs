using Refugee.Data;
using Refugee.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private RefugeeDbContext dataContext;
        public RefugeeDbContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new RefugeeDbContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}