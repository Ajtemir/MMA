using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMA.FrontMVC.Areas.Common.Controllers
{
    public class UsersController : Controller
    {
        // GET: Common/Users
        public ActionResult Index()
        {
            return View();
        }
    }
}