using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Services
{
    public interface IUserService : IServices<User>
    {
        User getUserByID(string id);
        User getUserByRoleVolunteer();
        User getUserByRoleMember();
        User getUserByToken(string t);
        void updateUser(User u);
    }
}
