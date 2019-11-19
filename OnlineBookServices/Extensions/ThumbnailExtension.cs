using OnlineBookServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookServices.Extensions
{
    public static class ThumbnailExtension //extension class remains always static
    {
        public static IEnumerable<ThumbnailModel> GetBookThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null)
        {
            try
            {

            if(db == null)
            {
                db = ApplicationDbContext.Create();
            }

            thumbnails = (from b in db.Books
                          select new ThumbnailModel
                          {
                              //BookId = b.Id,
                              Id = b.Id,
                              Title = b.Title,
                              Description = b.Description,
                              ImageUrl = b.ImageUrl,
                              Link = "/BookDetail/Index/" + b.Id
                          }).ToList();
            }
            catch(Exception ex)
            {

            }
            return thumbnails.OrderBy(b => b.Title);
        }
               
    }
}