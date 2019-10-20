using OnlineBookServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            return View(db.Genres.ToList()); //retrives genre from db and converts to the list and passes to the view
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
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// this method will return the Genre details /function, and pass genre id 
        /// if id is null, then returns bad request, 
        /// then  finds id from Genre tables in db and passess to genre,
        /// if genre is null, then returns httpNotFound,
        /// if genre is found, then genre is returned (view)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if(genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        /// <summary>
        /// Edit Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(Genre genre)
        {
            if(ModelState.IsValid)
            {
                //find genre frm db, getgenre ID and 
                /*var GenreInDb = db.Genres.FirstOrDefault(g => g.Id.Equals(genre.Id));
                  GenreInDb.Name = genre.Name;*/
                //this makes changes to all column , saves changes and redirects to index
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// Genre Delete , gets id as edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}