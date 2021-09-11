using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Constant;
using SocialNetwork.DAL;
using SocialNetwork.Models;
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
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            if (user.Role == Common .ADMIN_ROLE)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("");
        }
    }
}
