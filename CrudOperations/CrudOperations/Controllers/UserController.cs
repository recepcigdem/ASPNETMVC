using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudOperations.Models;
using AppContext = CrudOperations.Models.AppContext;

namespace CrudOperations.Controllers
{
    public class UserController : Controller
    {

        private Models.AppContext _appContext;

        public UserController()
        {
            _appContext = new Models.AppContext();
        }

        public ActionResult UserList()
        {

            var user = _appContext.Users.ToList();
            return View(user);
        }

        public ActionResult UserInfo()
        {
            return View(new User { id = 0 });
        }

        public ActionResult SaveUser(User user)
        {
            if (!ModelState.IsValid)
                return View("UserInfo", user);

            if (user.id == 0)
                _appContext.Users.Add(user);

            else
            {
                var userFromDb = _appContext.Users.FirstOrDefault(u => u.id == user.id);

                if (userFromDb == null)
                    return HttpNotFound();
                

                userFromDb.FirstName = user.FirstName;
                userFromDb.LastName = user.LastName;
                userFromDb.Email = user.Email;
                userFromDb.Password = user.Password;

            }
            _appContext.SaveChanges();

            return RedirectToAction("UserList");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var user = _appContext.Users.FirstOrDefault(u => u.id == id);

            if (user == null)
                return HttpNotFound();

            return View("UserInfo", user);
        }

        protected override void Dispose(bool disposing)
        {
            _appContext.Dispose();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var user = _appContext.Users.FirstOrDefault(u => u.id == id);

            if (user == null)
                return HttpNotFound();

            _appContext.Users.Remove(user);
            _appContext.SaveChanges();

            return RedirectToAction("UserList");
        }
    }
}