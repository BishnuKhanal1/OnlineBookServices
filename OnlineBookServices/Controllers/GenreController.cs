using OnlineBookServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookServices.Controllers
{
    public class GenreController : Controller
    {
        
        private ApplicationDbContext db; //added as using statement to initialize db

        public GenreController() //constructor
        {
            db = new ApplicationDbContext(); 
        }

        // GET: Genre
        public ActionResult Index() //here to display table with all rows in db
                                    //and display complete genre
        {
            return View(db.Genre.ToList()); //retrives genre from db and converts to the list and passes to the view
        }

        //adding another action to create genre 
        /// <summary>
        /// /this action will create a genre
        /// </summary>
        /// <returns></returns>
        /// This is a Get Action
        public ActionResult Create() //creating just a new genre, no need to pass anything in the view for that
        {
            return View();
        }

        //creating Post Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid) //validates attributes from genra model and save changes
            {
                db.Genre.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}