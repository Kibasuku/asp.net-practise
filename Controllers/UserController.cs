using Accounting.Data;
using Accounting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Accounting.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET Login
        public IActionResult Login()
        {
            return View();
        }

        //POST Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User model)
        {
            if(ModelState.IsValid)
            {
                User user = null;
                user = _db.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                if(user!=null)
                {
                    if (user.UserLevel == "1")
                    {
                        //FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("AllUsers", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином и паролем не найден");
                }  
            }
            return View(model);
        }

        public IActionResult AllUsers()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);

        }
        //GET Create
        public IActionResult Create()
        {
            return View();

        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("AllUsers");
            }
            return View(obj);

        }
        //GET Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST Delet
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Users.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("AllUsers");

        }

        //GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(User obj)
        {

            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("AllUsers");
            }
            return View(obj);

        }
    }
}
