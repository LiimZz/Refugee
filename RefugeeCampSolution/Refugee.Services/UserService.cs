using Refugee.Domain.Entities;
using Refugee.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refugee.Data.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace Refugee.Services
{
    public class UserService : Services<User>, IUserService
    {
        public static IDatabaseFactory dbFactory;
        public static IUnitOfWork myUnit;

        public UserService() : base(myUnit)
        {
            dbFactory = new DatabaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }

        public User getUserByID(string UserID)
        {
            return myUnit.getRepository<User>().GetById(UserID);
        }

        public User getUserByRoleMember()
        {
            return myUnit.getRepository<User>().Get(c => c.UserRole.Equals("Member"));
        }

        public User getUserByRoleVolunteer()
        {
            return myUnit.getRepository<User>().Get(c => c.UserRole.Equals("Volunteer"));
        }

        public User getUserByToken(string t)
        {
            return myUnit.getRepository<User>().Get(c => c.Token.Equals(t));
        }

        public void updateUser(User u)
        {
            myUnit.getRepository<User>().Update(u);
            myUnit.Commit();
        }
    }
}
