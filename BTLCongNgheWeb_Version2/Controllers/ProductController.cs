using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Models;
using BTLCongNgheWeb_Version2.Entity;
namespace BTLCongNgheWeb_Version2.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index(int id)
        {
            ProductDao prodcut_dao = new ProductDao();
            IEnumerable<CF_Products_Categories> list = prodcut_dao.ListProductByCategoryID(id);
            return View("Index",list);
        }
	}
}