using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectExpenseControl.CustomAuthentication;

namespace ProjectExpenseControl.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}