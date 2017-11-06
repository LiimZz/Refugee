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
    public class CommentController : Controller
    {
        ICommentService cs;

        public CommentController()
        {
            cs = new CommentService();
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            var c = cs.GetAllS();
            List<CommentViewModels> Pvm = new List<CommentViewModels>();
            foreach (var item in c)
            {
                Pvm.Add(
                    new CommentViewModels
                    {
                        PostID = item.PostID,
                        Content = item.Content,
                        DateComment = item.DateComment,
                        MemberID = item.MemberID
                    });
            }
            return View(Pvm);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CommentViewModels cvm)
        {
            Comment c = new Comment
            {
                Content = cvm.Content,
                MemberID = "7",
                PostID = 1,
                DateComment = DateTime.Now
            };

            cs.Add(c);
            cs.Commit();
            return RedirectToAction("Details");
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int PostId, string MemberID, DateTime date)
        {
            var c = cs.getById(PostId, MemberID, date);
            cs.Delete(c);
            cs.Commit();
            return RedirectToAction("detail");
        }
    }
}
