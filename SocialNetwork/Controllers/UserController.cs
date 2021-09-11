
using System.Collections.Generic;
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Index(int? categoryId = 1)
        {
            var news = newService.GetByCategoryId(categoryId);
            foreach (var item in news)
            {
                item.User = userService.GetUserById(item.UserId);
                item.Time = "One day ago";
            }
            ViewBag.Categories = categoryService.Get();
            ViewBag.CurrentUser = new User() { Avatar= "https://danviet.mediacdn.vn/2021/5/5/1-16201893641271008335156.jpg" };
            return View(news);
        }

    }
}
