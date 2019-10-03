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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}