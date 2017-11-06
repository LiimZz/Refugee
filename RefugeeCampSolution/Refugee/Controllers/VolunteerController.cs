using Microsoft.AspNet.Identity;
using Refugee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Refugee.Models;
using Refugee.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Refugee.Services;

namespace Refugee.Controllers
{
    public class VolunteerController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        RefugeeDbContext ctx;
        IUserService us;

        public VolunteerController()
        {
            ctx = new RefugeeDbContext();
            us = new UserService();
        }

        public VolunteerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            //var queryString = "SELECT AspNetUsers.UserName FROM dbo.AspNetUsers INNER JOIN dbo.AspNetUserRoles ON " + "AspNetUsers.Id=AspNetUserRoles.UserId WHERE AspNetUserRoles.RoleID='f3b84ce3-9de2-4b42-a2ed-261584acc421'";
            //var refug = HttpContext.GetOwinContext().Get<RefugeeDbContext>();
            //var users = from u in refug.Users
            //            from ur in u.Roles
            //            join r in refug.Roles on ur.RoleId equals "f3b84ce3-9de2-4b42-a2ed-261584acc421"
            //            select new
            //            {
            //                u.Id,
            //                Name = u.UserName,
            //                Role = r.Name,
            //            };
            var u = us.getUserByRoleVolunteer();
            return View(u);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Email = model.Email, UserRole = "Volunteer" };
                ActiveDirectory AD = new ActiveDirectory();
                AD.CreateUserAccount(model.UserName, model.Password);

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    await this.UserManager.AddToRoleAsync(user.Id, "Volunteer");
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
