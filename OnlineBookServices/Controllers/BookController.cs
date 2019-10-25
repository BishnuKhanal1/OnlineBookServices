using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineBookServices.Models;
using OnlineBookServices.ViewModel;

namespace OnlineBookServices.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            //include statement (either loading/books are connected to Genre by Genre ID
            //include statement finds book connected to Genre and passes to the books view
            //include requires 'using' statement which uses system.data.entity
            var books = db.Books.Include(b => b.Genre); 
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };

            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var genre = db.Genres.ToList();
            var model = new BookViewModel
            {
                Genres = genre
            };
            return View(model);
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookvm)
        {
            var book = new Book
            {
                Author = bookvm.Book.Author,
                Availablity = bookvm.Book.Availablity,
                DateAdded = bookvm.Book.DateAdded,
                Description = bookvm.Book.Description,
                Genre = bookvm.Book.Genre,
                GenreId = bookvm.Book.GenreId,
                ImageUrl = bookvm.Book.ImageUrl,
                ISBN = bookvm.Book.ISBN,
                Pages = bookvm.Book.Pages,
                Price = bookvm.Book.Price,
                Publisher = bookvm.Book.Publisher,
                ProductDimensions = bookvm.Book.ProductDimensions,
                PublicationDate = bookvm.Book.PublicationDate,
                Title = bookvm.Book.Title
            };

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            bookvm.Genres = db.Genres.ToList();

            return View(bookvm);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };
            //ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", book.GenreId);
            return View(model);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel bookvm)
        {
            var book = new Book
            {
                Id = bookvm.Book.Id, //Id added to edit the book
                Author = bookvm.Book.Author,
                Availablity = bookvm.Book.Availablity,
                DateAdded = bookvm.Book.DateAdded,
                Description = bookvm.Book.Description,
                Genre = bookvm.Book.Genre,
                GenreId = bookvm.Book.GenreId,
                ImageUrl = bookvm.Book.ImageUrl,
                ISBN = bookvm.Book.ISBN,
                Pages = bookvm.Book.Pages,
                Price = bookvm.Book.Price,
                Publisher = bookvm.Book.Publisher,
                ProductDimensions = bookvm.Book.ProductDimensions,
                PublicationDate = bookvm.Book.PublicationDate,
                Title = bookvm.Book.Title
            };
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", book.GenreId);
            bookvm.Genres = db.Genres.ToList();
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };

            return View(model);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
    }
}
