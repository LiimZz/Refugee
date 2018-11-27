using Refugee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Refugee.Controllers
{
    public class EmailController : Controller
    {
        //IUserService usrs;
        public EmailController()
        {
            //usrs = new UserService();
        }

        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        // GET: Email/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string recieverEmail, string subject, string message)
        {
                    var senderemail = new MailAddress("slimz.kh92@gmail.com", "RefugeeAdmin");
                    var recieveremail = new MailAddress(recieverEmail, "Reciever");
                    var password = "***************";

                var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)
                    };
                    using (var mess = new MailMessage(senderemail, recieveremail)
                    {
                        Subject = subject,
                        Body = body
                    }
                        )
                    {
                        smtp.Send(mess);
                    }
                    return View();
        }
    }
}
