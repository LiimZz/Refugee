using Microsoft.AspNet.Identity;
using Refugee.Domain.Entities;
using Refugee.Models;
using Refugee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Refugee.Controllers
{
    [Authorize(Roles = "SPAdmin")]
    public class RefugController : Controller
    {
        IRefugService rs = null;
        //ITentService ts = null;

        public RefugController()
        {
            rs = new RefugService();
            //ts = new TentService();
        }

        // GET: Refug
        public ActionResult Index()
        {
            var r = rs.GetAllRefug();
            return View(r);
        }

        // GET: Refug/Details/5
        public ActionResult Details(int id)
        {
            var r = rs.GetRefugByID(id);
            return View(r);
        }

        // GET: Refug/Create
        public ActionResult Create()
        {
            //var r = new Refug();
            return View();
        }

        // POST: Refug/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Refug rf)
        {
            Refug r = new Refug
            {
                AdminID = User.Identity.GetUserId(),
                FirstName = rf.FirstName,
                MiddleName = rf.MiddleName,
                LastName = rf.LastName,
                Age = rf.Age,
                Nationality = rf.Nationality,
                Staus = rf.Staus,
                TentID = 1
            };

            rs.CreateRefug(r);
            return RedirectToAction("Index", "Refug");
        }

        //GET: Refug/Delete/5
        public ActionResult Delete(int id)
        {
            var r = rs.GetRefugByID(id);
            rs.DeleteRefug(r);
            return RedirectToAction("Index", "Refug");
        }

        // GET: Refug/Edit/5
        public ActionResult Edit(int id)
        {
            Refug r = rs.GetRefugByID(id);
            return View(r);
        }

        // POST: Refug/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Refug rf)
        {
            try
            {
                Refug r = rs.GetRefugByID(id);

                r.AdminID = User.Identity.GetUserId();
                r.FirstName = rf.FirstName;
                r.MiddleName = rf.MiddleName;
                r.LastName = rf.LastName;
                r.Nationality = rf.Nationality;
                r.Age = rf.Age;
                r.Staus = rf.Staus;
                r.TentID = 1;

                rs.UpdateRefug(r);
                return RedirectToAction("Index", "Refug");
            }
            catch
            {
                return RedirectToAction("Edit", "Refug");
            }
        }
    }
}
