using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.MVCUI.Controllers
{
    [Authorize(Roles = "Admin")]//admin@gmail.com C@de1234
    public class AdminManagerController : Controller
    {
        // GET: AdminManager
        public ActionResult Index()
        {
            return View();
        }
    }
}