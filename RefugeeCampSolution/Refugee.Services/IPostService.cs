using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Services
{
    public interface IPostService : IServices<Post>
    {
        Post getPostByID(int id);
    }
}
