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
    public class UserController : Controller
    {
        private UserService service = new UserService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
    }
}
