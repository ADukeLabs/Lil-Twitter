using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Joker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Joker.Controllers
{
    public class HomeController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        ApplicationDbContext db = new ApplicationDbContext();

        public HomeController()
        {
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.db));   
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Profile()
        {
            
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            var jokes = currentUser.Jokes.ToList();
            return View(jokes);
        }
    }
}