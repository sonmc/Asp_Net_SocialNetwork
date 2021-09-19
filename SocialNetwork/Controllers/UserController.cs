
using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Constant;
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
            if (user == null || user.Role == Common.ADMIN_ROLE || !user.IsActive)
            {
                ViewBag.Invalid = "Account is invalid!";
                return RedirectToAction("Login");
            }
            Session["User"] = user;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index(int? categoryId = 1)
        {
            var currentUser = Session["User"] as User;

            if (currentUser == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.CurrentUser = currentUser;
            var news = newService.GetByCategoryId(categoryId);
            foreach (var item in news)
            {
                item.User = userService.GetUserById(item.UserId);
                CultureInfo culture = new CultureInfo("en-US");
                var datetimeCreated = Convert.ToDateTime(item.DateCreated, culture);
                item.Time = Common.GetTime(datetimeCreated);
            }
            ViewBag.FriendRequest = userService.GetFriendsRequest(currentUser.Id);
            ViewBag.Friends = userService.GetFriends(currentUser.Id);
            ViewBag.FriendAround = userService.GetUser(currentUser.Id);
            ViewBag.Categories = categoryService.Get();
            ViewBag.SharePosts = userService.GetPostShared(currentUser.Id);
            return View(news);
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            string fileName = "";
            bool isFileUploaded = false;
            try
            {
                var file = Request.Files[0];
                if (file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                    file.SaveAs(_path);
                    isFileUploaded = true;
                }
            }
            catch
            {
                isFileUploaded = false;
                fileName = "";
            }
            return Json(new { status = isFileUploaded, data = fileName });
        }
        public JsonResult CreatePost(int userId, string content, int categoryId, string img)
        {
            New obj = newService.Create(userId, content, categoryId, img);
            return Json(obj);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult DeleteNew(int id)
        {
            newService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateNew(int id)
        {
            var newObj = newService.GetById(id);
            return View(newObj);
        }
        [HttpPost]
        public JsonResult AddFriend(int toId)
        {
            var currentUser = Session["User"] as User;
            var friendAdded = userService.AddFriend(currentUser.Id, toId);
            return Json(friendAdded);
        }

        [HttpPost]
        public JsonResult UserFriendAccept(int friendId)
        {
            var currentUser = Session["User"] as User;
            var friendAdded = userService.AcceptFriend(friendId, currentUser.Id);
            return Json(friendAdded);
        }

        [HttpPost]
        public JsonResult UserFriendRemove(int friendId)
        {
            var currentUser = Session["User"] as User;
            var isRemoved = userService.RemoveFriendRequest(friendId, currentUser.Id);
            return Json(isRemoved);
        }

        [HttpPost]
        public JsonResult SharePostToFriend(int friendId, int postId)
        {
            var currentUser = Session["User"] as User;
            bool shared = userService.SharePostToFriend(currentUser.Id, friendId, postId);
            return Json(shared);
        }
        [HttpGet]
        public JsonResult GetNewDetail(int newId)
        {
            var newObj = newService.GetById(newId);
            return Json(newObj, JsonRequestBehavior.AllowGet);
        }
    }
}
