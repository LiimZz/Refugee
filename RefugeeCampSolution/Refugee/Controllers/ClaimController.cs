using Microsoft.AspNet.Identity;
using Refugee.Domain.Entities;
using Refugee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugee.Controllers
{
    [Authorize]
    public class ClaimController : Controller
    {
        IClaimService ClmServ;

        public ClaimController()
        {
            ClmServ = new ClaimService();
        }

        // GET: Claim
        public ActionResult Index()
        {
            var c = ClmServ.getAllClaims();
            return View(c);
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostClaims pc)
        {
            PostClaims p = new PostClaims
            {
                MemberID = User.Identity.GetUserId(),
                PostID = 1,
                DateClaim = DateTime.Now,
                Description = pc.Description,
                Objet = pc.Objet,
                Status = "Not Treated yet",
            };

            ClmServ.createClaim(p);
            ClmServ.Commit();
            return RedirectToAction("Index", "Post");
        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int idp, string idu)
        {
            PostClaims pclm = ClmServ.getClaimByID(idp, idu);
            pclm.Status = "Treated";

            ClmServ.updateClaim(pclm);
            return RedirectToAction("Create", "Email");
        }

        // POST: Claim/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idp, string idu, PostClaims pc)
        {
                //PostClaims pclm = ClmServ.getClaimByID(idp, idu);

                //pclm.Status = pc.Status;

                //ClmServ.updateClaim(pclm);
                return RedirectToAction("Index", "Claim");
        }

        public ActionResult Delete(int idp, string idu)
        {
            ClmServ.deleteClaim(idp, idu);
            return RedirectToAction("Index");
        }

        public ActionResult ExportPdf()
        {
            return new Rotativa.MVC.ActionAsPdf("Index")
            {
                FileName = Server.MapPath("~/Content/ClaimsList.pdf")
            };
        }

    }
}
