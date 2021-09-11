 
using System.Web.Mvc;
using SocialNetwork.Constant; 
using SocialNetwork.Entities;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    public class AdminController : Controller
    {
        private UserService service = new UserService();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pwd)
        {
            User user = service.Login(email, pwd);
            if (user != null)
            {
                return RedirectToAction("Index");
            } 
            return RedirectToAction("Login");
        }
    }
}
