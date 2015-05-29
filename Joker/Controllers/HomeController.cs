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
        public ActionResult Profile(int jokeId)
        {
            JokeViewModel jvm = new JokeViewModel();
            
            var currentUser = UserManager.FindById(User.Identity.GetUserId());
            var jokes = currentUser.Jokes.ToList();


            var joke = db.Jokes.Find(jokeId);
            joke.ApplicationUser.Followers.Add(currentUser);

            db.SaveChanges();
            jvm.JokeList = currentUser.Jokes.ToList();
            jvm.joke = new Joke();
            return View(jvm);
        }
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Profile(Joke joke)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var id = User.Identity.GetUserId();
        //        joke.ApplicationUser = UserManager.FindById(id);

        //        //var UserFromDb = db.Users.Single(s => s.Id == id)

        //        db.Jokes.Add(joke);
        //        db.SaveChanges();
        //        return View();
        //    }

        //    return View();
        //}

    }
}