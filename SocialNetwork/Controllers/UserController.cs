 
using System.Web.Mvc;
using SocialNetwork.Entities;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {
        private NewService newService = new NewService();
        private UserService userService = new UserService();
        private CategoryService categoryService = new CategoryService();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string pwd)
        {
            User user = userService.Login(email, pwd);
            if (user != null)
            {
                Session["User"] = user;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Index(int? categoryId = 1)
        {
            var currentUser = Session["User"];
           
            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.CurrentUser = currentUser;
            var news = newService.GetByCategoryId(categoryId);
            foreach (var item in news)
            {
                item.User = userService.GetUserById(item.UserId);
                item.Time = "One day ago";
            }
            ViewBag.FriendAround = userService.Get();
            ViewBag.Categories = categoryService.Get();
            
            return View(news);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Delete(int id)
        {
             newService.Delete(id); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            return RedirectToAction("Index");
        }
    }
}
