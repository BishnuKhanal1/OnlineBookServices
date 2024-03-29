﻿using OnlineBookServices.Models;
using OnlineBookServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookServices.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db;

        //add constructor

        public UserController()
        {
            db = ApplicationDbContext.Create();
        }
        // GET: User
        public ActionResult Index()
        {
            var user = from u in db.Users
                       join m in db.MembershipTypes on u.MembershipTypeId equals m.Id
                       select new UserViewModel //getting user (from) UserViewModel
                       {
                           Id = u.Id,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Email = u.Email,
                           Phone = u.Phone,
                           BirthDate = u.BirthDate,
                           MembershipTypeId = u.MembershipTypeId,
                           MembershipTypes = (ICollection<MembershipType>)db.MembershipTypes.ToList().Where(n => n.Id.Equals(u.MembershipTypeId)),
                           Disable = u.Disable
                          
                       };
            //converting the users into the list
            var userList = user.ToList();
            //pass users list to the view
            return View(userList);
        }

        //EDIT GET
       public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if(user == null)
            {
                return HttpNotFound();
            }

            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Id = user.Id,
                MembershipTypeId = user.MembershipTypeId,
                MembershipTypes = db.MembershipTypes.ToList(),
                Phone = user.Phone,
                Disable = user.Disable
            };
            return View(model);
        }



        //EDIT POST : Post method for edit action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                UserViewModel model = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Id = user.Id,
                    MembershipTypeId = user.MembershipTypeId,
                    MembershipTypes = db.MembershipTypes.ToList(),
                    Phone = user.Phone,
                    Disable = user.Disable
                };

                return View("Edit", model);
            }
            else
            {
                var userInDb = db.Users.Single(u => u.Id == user.Id);
                userInDb.FirstName = user.FirstName;
                userInDb.LastName = user.LastName;
                userInDb.BirthDate = user.BirthDate;
                userInDb.Email = user.Email;
                userInDb.MembershipTypeId = user.MembershipTypeId;
                //userInDb.MembershipTypes = db.MembershipTypes.ToList();
                userInDb.Phone = user.Phone;
                userInDb.Disable = user.Disable;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        //Details

        public ActionResult Details(string id)
        {
            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);

            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Id = user.Id,
                MembershipTypeId = user.MembershipTypeId,
                MembershipTypes = db.MembershipTypes.ToList(),
                Phone = user.Phone,
                Disable = user.Disable
            };
            return View(model);
        }


        //Delete GET method

        public ActionResult Delete(string id)
        {
            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);

            UserViewModel model = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Id = user.Id,
                MembershipTypeId = user.MembershipTypeId,
                MembershipTypes = db.MembershipTypes.ToList(),
                Phone = user.Phone,
                Disable = user.Disable
            };
            return View(model);
        }

        //DELETE Post method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(string id)
        {
            var userInDb = db.Users.Find(id);
            if (id == null || id.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userInDb.Disable = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
        }
    }
}