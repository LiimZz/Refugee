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

        public PostService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }

        public Post getPostByID(int PostID)
        {
            return myUnit.getRepository<Post>().GetById(PostID);
        }
    }
}
