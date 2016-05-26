using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Models;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class ShoppingCardController : Controller
    {
        //
        // GET: /Admin/ShoppingCard/
        public ActionResult Index()
        {
            ShopingCart sp = (ShopingCart)Session["Card"];
            if (sp != null)
            {
                //sp.DeleteCard(id);
                Session["Card"] = sp;
            }
            return View();
        }
	}
}