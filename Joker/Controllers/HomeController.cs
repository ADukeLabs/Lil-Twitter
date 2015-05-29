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
            JokeViewModel jvm = new JokeViewModel();
            
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            
            jvm.JokeList = currentUser.Jokes.ToList();
            jvm.joke = new Joke();
            jvm.Following = currentUser.Following;
            jvm.Followers = currentUser.Followers;
            return View(jvm);
        }

        [Authorize]
        public ActionResult Following(int jokeId)
        {
           var currentUser = UserManager.FindById(User.Identity.GetUserId());
        
            var joke = db.Jokes.Find(jokeId);

            currentUser.Following.Add(joke.ApplicationUser);


            db.SaveChanges();
           
            return RedirectToAction("Profile");
        }
    }
}