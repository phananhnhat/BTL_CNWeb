using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Admin/Account/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserLogin"] = null;
            return RedirectToAction("Index", "Login", new { Area = "" });
        }
        public ActionResult ChangePassWord()
        {
            return View();
        }
	}
}