using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Services
{
    public interface IRefugService : IServices<Refug>
    {
        void CreateRefug(Refug r);
        List<Refug> GetAllRefug();
        void UpdateRefug(Refug r);
        Refug GetRefugByID(int RefugID);
        List<Refug> GetRefugByTentID(int TentID);
        void DeleteRefug(Refug r);

    }
}
