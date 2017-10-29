using Refugee.Data.Infrastructure;
using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Services
{
    public class RefugService : Services<Refug>, IRefugService
    {
        public static IDatabaseFactory dbFactory;
        public static IUnitOfWork myUnit;

        public RefugService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }

        public void CreateRefug(Refug r)
        {
            myUnit.getRepository<Refug>().Add(r);
            myUnit.Commit();
        }

        public void DeleteRefug(Refug r)
        {
            myUnit.getRepository<Refug>().Delete(r);
            myUnit.Commit();
        }

        public List<Refug> GetAllRefug()
        {
            return myUnit.getRepository<Refug>().GetAll().ToList();
        }

        public Refug GetRefugByID(int RefugID)
        {
            return myUnit.getRepository<Refug>().GetById(RefugID);
        }

        public List<Refug> GetRefugByTentID(int TentID)
        {
            return GetMany(t => t.TentID == TentID).ToList();
        }

        public void UpdateRefug(Refug r)
        {
            myUnit.getRepository<Refug>().Update(r);
            myUnit.Commit();
        }
    }
}
