using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Models;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class WareHouseController : Controller
    {
        //
        // GET: /Admin/WareHouse/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {

            ProductDao product_dao = new ProductDao();
            IEnumerable<Product> list = product_dao.ListProduct();
            return View("List",list);
        }
	}
}