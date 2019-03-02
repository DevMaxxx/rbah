using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using rbah.Models;

namespace rbah.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager authManager { get { return HttpContext.GetOwinContext().Authentication; } }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            if (ModelState.IsValid)
            {
                Account user = new Account() { UserName = model.name, Email = model.email };
                IdentityResult result = AccountManager.Instance.Create(user, model.password);
                if (result.Succeeded)
                {
                    Context.Instance.users.Add(new User(user.UserName));
                    Context.Instance.SaveChanges();
                    ClaimsIdentity claim = AccountManager.Instance.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignOut();
                    authManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true,
                    },claim);
                    return Redirect("/Home/Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            if (ModelState.IsValid)
            {
                Account account = AccountManager.Instance.Find(model.name, model.password);
                if(account != null)
                {
                    ClaimsIdentity claim = AccountManager.Instance.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignOut();
                    authManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true,
                    }, claim);
                    return Redirect("/Home/Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            authManager.SignOut();
            return Redirect("/Home/Index");
        }
    }
}