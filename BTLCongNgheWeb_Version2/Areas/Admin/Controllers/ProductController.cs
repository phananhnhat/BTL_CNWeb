using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Admin_Product_/
        public ActionResult List(int page = 1, int pageSize = 5)
        {
            ProductDao dao = new ProductDao();
            // IQueryable<Office> Offices = dao.Offices;
            //IQueryable<Product> p = dao.ListProduct();
            var list = dao.ListProduct(page, pageSize);
            return View("List", list);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ProductDao pDao = new ProductDao();
            Product p = pDao.FindProductByICode(id);

            ProductImageDao iDao = new ProductImageDao();
            IQueryable<ProductImage> listImage = iDao.FindImage(id);
            ViewBag.Image = listImage;

            IQueryable<CF_Products_Categories> listCF_P_Cat = pDao.Find_CF_Product_Categories(id);
            ViewBag.CF_Category = listCF_P_Cat;

            CategoryDao cDao = new CategoryDao();
            IQueryable<Category> listCates = cDao.ListCategory();
            ViewBag.Category = listCates;
            return View(p);
        }

        public ActionResult AddAction(Product p, string[] Category, string URL)
        {
            ProductDao pDao = new ProductDao();
            pDao.InsertProduct(p.NameProduct, p.FullNameProduct, p.Qty, p.Price, p.News, p.Sale, p.PriceSale, p.Color,
                p.Size, p.Maker, p.Description, p.Note, p.Actives, p.CreateByEmployeeID, Category, URL);
            //foreach (string category in Category)
            //{
            //    int int_categoryid = Int32.Parse(category);

            //}
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            ProductDao pDao = new ProductDao();
            Product p = pDao.FindProductByICode(id);

            ProductImageDao iDao = new ProductImageDao();
            IQueryable<ProductImage> listImage = iDao.FindImage(id);
            ViewBag.Image = listImage;

            IQueryable<CF_Products_Categories> listCF_P_Cat = pDao.Find_CF_Product_Categories(id);
            ViewBag.CF_Category = listCF_P_Cat;

            CategoryDao cDao = new CategoryDao();
            IQueryable<Category> listCates = cDao.ListCategory();
            ViewBag.Category = listCates;

            return View(p);
        }

        public ActionResult EditAction(Product p, string[] Category, string URL)
        {
            ProductDao pDao = new ProductDao();
            pDao.UpdateProduct(p, Category, URL);
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            ProductDao pDao = new ProductDao();
            Product p = pDao.FindProductByICode(id);
            pDao.DeleteProduct(p);
            return RedirectToAction("List");
        }
	}
}