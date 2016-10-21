using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySinhVien.Web.Areas.Admin.Controllers
{
    [Authorize]
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            return RedirectToAction("LogOff2", "Account", new {area = ""});
        }
    }
}