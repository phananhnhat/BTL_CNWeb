using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class BlankController : Controller
    {
        //
        // GET: /Admin/Blank/
        public ActionResult Blank()
        {
            return View();
        }
	}
}