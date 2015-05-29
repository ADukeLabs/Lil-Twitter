using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Joker.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Joker.Controllers
{
    public class JokeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public JokeController()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }


        // GET: Joke
         [Authorize]
        public ActionResult Index()
        {
            JokeViewModel jvm = new JokeViewModel();
            var id = User.Identity.GetUserId();
            jvm.user = UserManager.FindById(id).UserName;
             
            jvm.JokeList = db.Jokes.ToList();

            jvm.joke = new Joke();
            return View(jvm);
        }


        // GET: Joke/Details/5
         [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joke joke = db.Jokes.Find(id);
            if (joke == null)
            {
                return HttpNotFound();
            }
            return View(joke);
        }

     // POST: Joke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Joke joke)
        {
            if (ModelState.IsValid)
            {
                var id = User.Identity.GetUserId();
                joke.ApplicationUser = UserManager.FindById(id);

                //var UserFromDb = db.Users.Single(s => s.Id == id);

                db.Jokes.Add(joke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Joke/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joke joke = db.Jokes.Find(id);
            if (joke == null)
            {
                return HttpNotFound();
            }
            return View(joke);
        }

        // POST: Joke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Joke joke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(joke);
        }

        // GET: Joke/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joke joke = db.Jokes.Find(id);
            if (joke == null)
            {
                return HttpNotFound();
            }
            return View(joke);
        }

        // POST: Joke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Joke joke = db.Jokes.Find(id);
            db.Jokes.Remove(joke);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult Profilemm(string s)
        //{
        //    return Redirect("Profile","Home");
        //}
    }
}
