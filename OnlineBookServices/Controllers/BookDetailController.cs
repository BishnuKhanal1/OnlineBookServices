using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OnlineBookServices.Models;
using Microsoft.AspNet.Identity;
using OnlineBookServices.Utility;
using OnlineBookServices.ViewModel;

namespace OnlineBookServices.Controllers
{
    public class BookDetailController : Controller
    {
        private ApplicationDbContext db;

        public BookDetailController()
        {
            db = ApplicationDbContext.Create();
        }

        // GET: BookDetail
        public ActionResult Index(int id)
        {
            var userid = User.Identity.GetUserId(); //retrives user id, 
            var user = db.Users.FirstOrDefault(u => u.Id == userid); //based on the user id, it retrieves all properties from database

            var bookModel = db.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);//bookmodel will retrives all book models and associated genre of that book

            var sellingPrice = 0.0;
            var rentalPrice = 0.0;
            var oneMonthRental = 0.0;
            var sixMonthRental = 0.0;
            var rentalCount = 0;
            if (userid != null && !User.IsInRole(SD.AdminUserRole))
            {
                var chargeRate = from u in db.Users
                                 join m in db.MembershipTypes on u.MembershipTypeId equals m.Id
                                 where u.Id.Equals(userid)
                                 select new { m.SellingPrice, m.ChargeRateOneMonth, m.ChargeRateSixMonth, /*u.RentalCount*/ };

                oneMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateOneMonth) / 100;
                sixMonthRental = Convert.ToDouble(bookModel.Price) * Convert.ToDouble(chargeRate.ToList()[0].ChargeRateSixMonth) / 100;
                sellingPrice = Convert.ToDouble(bookModel.Price);

               // rentalCount = Convert.ToInt32(chargeRate.ToList()[0].RentalCount);
            }

            BookServiceViewModel model = new BookServiceViewModel
            {
                BookId = bookModel.Id,
                ISBN = bookModel.ISBN,
                Author = bookModel.Author,
                Availability = bookModel.Availablity,
                DateAdded = bookModel.DateAdded,
                Description = bookModel.Description,
                Genre = db.Genres.FirstOrDefault(g => g.Id.Equals(bookModel.GenreId)),
                GenreId = bookModel.GenreId,
                ImageUrl = bookModel.ImageUrl,
                Pages = bookModel.Pages,
                Price = bookModel.Price,
                Publisher = bookModel.Publisher,
                PublicationDate = bookModel.PublicationDate,
                ProductDimensions = bookModel.ProductDimensions,
                Title = bookModel.Title,
                UserId = userid,
                RentalPrice = rentalPrice,
                RentalPriceOneMonth = oneMonthRental,
                RentalPriceSixMonth = sixMonthRental,
                RentalCount = rentalCount

            };

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}