using rbah.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;

namespace rbah.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticationManager authManager { get { return HttpContext.GetOwinContext().Authentication; } }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.name = HttpContext.User.Identity.Name;
            List<Publish> publish = new List<Publish>();
            foreach(var p in Context.Instance.posts.ToList())
            {
                User n = Context.Instance.users.ToList().Find(b => b.id == p.autorId);
                Publish pu = new Publish(n.name, p.title,p.id);
                publish.Add(pu); //.SqlQuery("SELECT name FROM dbo.Users WHERE id=@p0", p.autorId)));
            }
            return View(publish);
        }
    }
}