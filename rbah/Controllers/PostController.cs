using Microsoft.Owin.Security;
using rbah.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace rbah.Controllers
{
    public class PostController : Controller
    {
        private IAuthenticationManager authManager { get { return HttpContext.GetOwinContext().Authentication; } }

        [HttpGet]
        public ActionResult Get(int id)
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.name = HttpContext.User.Identity.Name;
            return View(Context.Instance.posts.ToList().Find(x=>x.id == id));
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.name = HttpContext.User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostModel model)
        {
            ViewBag.isAuth = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.name = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                User user = Context.Instance.users.FirstOrDefault(x => x.name == HttpContext.User.Identity.Name);
                Post post = Context.Instance.posts.Add(new Post(user.id,model.postHead,model.postBody));
                Context.Instance.SaveChanges();
            }
            return Redirect("/Home/Index");
        }
    }
}