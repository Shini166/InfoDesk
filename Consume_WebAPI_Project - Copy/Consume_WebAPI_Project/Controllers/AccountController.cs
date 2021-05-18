using Consume_WebAPI_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Consume_WebAPI_Project.Controllers
{
    // GET: Account
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(user model)
        {
            using (var context = new AccountEntities())
            {

                bool loginIsValid = context.users.Any(x => x.user_name == model.user_name && x.user_password == model.user_password);

                if (loginIsValid)
                {
                    FormsAuthentication.SetAuthCookie(model.user_name, false);
                    return RedirectToAction("Index", "Paitent");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(user model)
        {
            using (var context = new AccountEntities())
            {
                context.users.Add(model);
                context.SaveChanges();
                return RedirectToAction("Login");
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}