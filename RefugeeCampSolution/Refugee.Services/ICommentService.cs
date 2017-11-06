using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Services
{
    public interface ICommentService : IServices<Comment>
    {
        void updatePub(Comment ct);
        void removeService(int idct);
        IEnumerable<Comment> GetAllS();
        Comment getById(int PostId, string MemberId, DateTime date);
    }
}
