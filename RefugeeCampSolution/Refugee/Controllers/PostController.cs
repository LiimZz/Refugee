using Refugee.Domain.Entities;
using Refugee.Models;
using Refugee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Refugee.Controllers
{
    public class PostController : Controller
    {
        IPostService ps;

        public PostController()
        {
            ps = new PostService();
        }

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var c = ps.GetAllS();
            List<PostViewModels> Pvm = new List<PostViewModels>();
            foreach (var item in c)
            {
                // User.Identity.GetUserId()
                if (item.MemberID == "1")
                {
                    Pvm.Add(
                     new PostViewModels
                     {
                         PostID = item.PostID,
                         Content = item.Content,
                         DatePub = item.DatePub,
                         Picture = item.Picture,
                         Like = item.Like,
                         Dislike = item.Dislike,

                     });
                }
            }
            return View(Pvm);
            int i = 0;
            Button b = new Button();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModels pmm, HttpPostedFileBase file)
        {
            Post p = new Post
            {
                Content = pmm.Content,
                DatePub = DateTime.Now,
                Dislike = 0,
                Like = 0,
                Picture = pmm.Picture
            };

            ps.Add(p);
            ps.Commit();
            return RedirectToAction("Details");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            Post p = ps.GetById(id);

            var PostModel = new PostViewModels
            {
                PostID = p.PostID,
                Content = p.Content,
                DatePub = p.DatePub,
                Dislike = p.Dislike,
                Like = p.Like,
                Picture = p.Picture,
                MemberID = p.MemberID
            };
            return View(PostModel);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostViewModels PostModel)
        {
            Post an = ps.GetById(id);

            an.Content = PostModel.Content;
            an.DatePub = DateTime.Now;
            an.Dislike = 0;
            an.Picture = PostModel.Picture;
            an.Like = 0;
            an.MemberID = "6";
            ps.Update(an);
            ps.Commit();

            return RedirectToAction("Details");
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            Post c = ps.getPostByID(id);
            ps.removeService(id);
            ps.Commit();
            return RedirectToAction("Details");
        }

        public ActionResult DetailAchref(int? id)
        {
            var c = ps.GetAllS();
            List<PostViewModels> Pvm = new List<PostViewModels>();
            foreach (var item in c)
            {
                Pvm.Add(
                    new PostViewModels
                    {
                        PostID = item.PostID,
                        Content = item.Content,
                        DatePub = item.DatePub,
                        Picture = item.Picture,
                        Like = item.Like,
                        Dislike = item.Dislike,
                    });
            }
            return View(Pvm);
            int i = 0;
            Button b = new Button();
        }

        [HttpPost]
        public ActionResult CreateAdmin(PostViewModels pmm, HttpPostedFileBase file)
        {
            Post p = new Post
            {
                Content = pmm.Content,
                DatePub = DateTime.Now,
                Dislike = 0,
                Like = 0,
                Picture = pmm.Picture
            };

            ps.Add(p);
            ps.Commit();
            return RedirectToAction("DetailAchref");
        }

        public ActionResult DetailAll(int? id)
        {
            var c = ps.GetAllS();
            List<PostViewModels> Pvm = new List<PostViewModels>();
            foreach (var item in c)
            {
                Pvm.Add(
                    new PostViewModels
                    {
                        PostID = item.PostID,
                        Content = item.Content,
                        DatePub = item.DatePub,
                        Picture = item.Picture,
                        Like = item.Like,
                        Dislike = item.Dislike,

                    });
            }
            return View(Pvm);
            int i = 0;
            Button b = new Button();
        }


    }
}
