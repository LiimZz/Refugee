using Refugee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        RefugeeDbContext DataContext { get; }
    }
}