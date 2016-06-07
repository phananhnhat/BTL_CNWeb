using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Models;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class Kho_hang_Controller : Controller
    {
        public ActionResult List()
        {
            Kho_hang_Dao p = new Kho_hang_Dao();
            List<Kho_hang> a = p.Listkhohang();

            return View(a);
        }

        public ActionResult Add()
        {
            return View();
        }
	}
}