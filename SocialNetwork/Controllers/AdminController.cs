
using System.Collections.Generic;
using System.Web.Mvc;
using SocialNetwork.Constant;
using SocialNetwork.Entities;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    public class AdminController : Controller
    {
        private UserService userService = new UserService();
        private NewService newService = new NewService();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            var currentUser = Session["CurrentUser"];
            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }
            List<User> users = userService.Get();
            ViewBag.CurrentUser = currentUser;
            return View(users);
        }
        public ActionResult New()
        {
            var currentUser = Session["CurrentUser"];
            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }
            List<New> news = newService.Get();
            ViewBag.CurrentUser = currentUser;
            return View(news);
        }

        public ActionResult Approve(int newId, bool isActive)
        {
            New objNew = newService.GetById(newId);
            objNew.IsApprove = isActive;
            newService.UpdateNew(objNew);
            return RedirectToAction("New");
        }
        public ActionResult Logout()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Login"); 
        }

        [HttpPost]
        public ActionResult Login(string email, string pwd)
        {
            User user = userService.Login(email, pwd);
            if (user != null && user.Role == Common.ADMIN_ROLE && user.IsActive)
            {
                Session["CurrentUser"] = user;
                return RedirectToAction("Index");
            }
            ViewBag.Invalid = "Account is invalid!";
            return RedirectToAction("Login");
        }
        public ActionResult ChangeStatus(int userId, bool isActive)
        {
            User user = userService.GetUserById(userId);
            user.IsActive = isActive;
            userService.UpdateUser(user);
            return RedirectToAction("Index");
        }

        public ActionResult Update(User user)
        {
            userService.UpdateUser(user);
            return RedirectToAction("Index");
        } 
        public JsonResult CreateUser(  string email, bool isAdmin )
        {
            var user = new User()
            {
                Email = email,
                Role = isAdmin ? Common.ADMIN_ROLE : Common.USER_ROLE,
                Password = "abc@123",
                IsActive = true
            };
            var userAdded = userService.Create(user);
            return Json(userAdded);
        }
        public ActionResult RemoveNew(int newId)
        {
            newService.Delete(newId);
            return RedirectToAction("New");
        }
    }
}
