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
    public class ClaimService : Services<PostClaims>, IClaimService
    {
        public static IDatabaseFactory dbFactory;
        public static IUnitOfWork myUnit;

        IPostService ps;
        IUserService us;

        public ClaimService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
            ps = new PostService();
            us = new UserService();
        }

        public void createClaim(PostClaims p)
        {
            myUnit.getRepository<PostClaims>().Add(p);
            myUnit.Commit();
        }

        public List<PostClaims> getAllClaims()
        {
            return myUnit.getRepository<PostClaims>().GetAll().ToList();
        }

        public void deleteClaim(int idp, string idu)
        {
            PostClaims d = myUnit.getRepository<PostClaims>().GetMany(c => c.PostID == idp && c.MemberID == idu).FirstOrDefault();
            myUnit.getRepository<PostClaims>().Delete(d);
            myUnit.Commit();
        }

        public PostClaims getClaimByID(int idp, string idu)
        {
            Post p = ps.getPostByID(idp);
            User u = us.getUserByID(idu);
            return myUnit.getRepository<PostClaims>().GetMany(c => c.PostID == p.PostID && c.MemberID == u.Id).FirstOrDefault();
        }

        public PostClaims getClaimByObject(string Objet)
        {
            return myUnit.getRepository<PostClaims>().GetById(Objet);
        }

        public void updateClaim(PostClaims p)
        {
            myUnit.getRepository<PostClaims>().Update(p);
            myUnit.Commit();
        }
    }
}
