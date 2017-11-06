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
    public class CommentService : Services<Comment>, ICommentService
    {
        public static IDatabaseFactory dbFactory;
        public static IUnitOfWork myUnit;
        RefugeeDbContext rt;
        IPostService ps;
        IUserService us;

        public CommentService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
            rt = new RefugeeDbContext();
            ps = new PostService();
            us = new UserService();
        }
        public IEnumerable<Comment> GetAllS()
        {
            return rt.Comment.ToList();
        }

        public Comment getById(int PostId, string MemberId, DateTime date)
        {
            Post p = ps.getPostByID(PostId);
            User u = us.getUserByID(MemberId);
            return myUnit.getRepository<Comment>().GetMany(c => c.PostID == p.PostID && c.MemberID == u.Id && c.DateComment == date).FirstOrDefault();
        }

        public void removeService(int idct)
        {
            Comment ct = this.GetById(idct);
            this.Delete(ct);
        }

        public void updatePub(Comment ct)
        {
            this.Add(ct);
            this.Commit();
        }
    }
}
