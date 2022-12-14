using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMA.Contract.Common;
using MMA.Domain.Common;

namespace MMA.FrontMVC.Areas.Common.Controllers
{
    public class UsersController : Controller
    {
        // GET: Common/Users
        public ActionResult Index()
        {
            var service = new ServiceClientFactory<ICommonService>().GetService();
            var user = service.GetUser();
            return View(new List<User> { user });
        }
    }
}