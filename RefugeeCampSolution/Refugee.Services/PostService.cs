using Refugee.Data;
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
    public class PostService : Services<Post>, IPostService
    {
        public static IDatabaseFactory dbFactory;
        public static IUnitOfWork myUnit;
        RefugeeDbContext ct;

        public PostService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
            ct = new RefugeeDbContext();
        }

        public IEnumerable<Post> GetAllS()
        {
            return ct.Post.ToList();
        }

        public Post getPostByID(int PostID)
        {
            return myUnit.getRepository<Post>().GetById(PostID);
        }

        public void removeService(int idPub)
        {
            Post pub = myUnit.getRepository<Post>().GetById(idPub);
            this.Delete(pub);
        }

        public void updatePub(Post pub)
        {
            this.Add(pub);
            this.Commit();
        }
    }
}
