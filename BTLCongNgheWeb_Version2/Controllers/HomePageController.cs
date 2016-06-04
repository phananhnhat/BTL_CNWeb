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
    public class HomePageController : Controller
    {
        //
        // GET: /HomePage/
        public ActionResult Index()
        {
            ProductDao iDao = new ProductDao();
            List<ViewProduct> listImage = iDao.ListViewProduct(6);
            ViewBag.ViewNewsProduct = listImage;

            return View();
        }

        public ActionResult Detail(int id)
        {
            ProductDao pDao = new ProductDao();
            Product p = pDao.FindProductByICode(id);

            ProductImageDao iDao = new ProductImageDao();
            IQueryable<ProductImage> listImage = iDao.FindImage(id);
            ViewBag.Image = listImage;

            IQueryable<CF_Products_Categories> listCF_P_Cat = pDao.Find_CF_Product_Categories(id);
            ViewBag.CF_Category = listCF_P_Cat;

            ProductDao pdDao = new ProductDao();
            List<ViewProduct> listImage2 = pdDao.ListViewProduct(10);
            ViewBag.ViewNewsProduct2 = listImage2;

            CategoryDao cDao = new CategoryDao();
            IQueryable<Category> listCates = cDao.ListCategory();
            ViewBag.Category = listCates;
            return View(p);
        }

        public ActionResult ListProductByCategory(int id)
        {
            CategoryDao cDao = new CategoryDao();
            Category c = cDao.FindCatById(id);
            ViewBag.NameCategory = c.Name;

            ProductDao pDao2 = new ProductDao();
            List<ViewProduct> vp = pDao2.ListProductByCategory(id);
            return View(vp);
        }
        public ActionResult HomePage()
        {
            return View();
        }
	}
}