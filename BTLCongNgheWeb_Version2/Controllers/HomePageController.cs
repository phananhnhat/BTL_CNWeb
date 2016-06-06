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
        public ActionResult Order()
        {
            CustomerDao cus_dao = new CustomerDao();
            ShopingCart donhang = new ShopingCart();
            donhang.listItem = new List<CardItem>();
            donhang.AddCard(new CardItem(1, "aaaaaa", 3, 32323));
            donhang.AddCard(new CardItem(4, "vvvvvvv", 3, 32323));
            donhang.AddCard(new CardItem(5, "bbbbb", 3, 32323));
            donhang.AddCard(new CardItem(6, "eeeee", 3, 32323));
            donhang.AddCard(new CardItem(7, "dddd", 3, 32323));
            donhang.AddCard(new CardItem(8, "gggggg", 3, 32323));
            Session["DonHang"] = donhang;
            if (Session["UserLogin"] != null)
            {
                Customer user_login = cus_dao.FindByID(((UserLogin)Session["UserLogin"]).ID);
                donhang.CustomerID = user_login.ID;
                donhang.TenKhachHang = user_login.Name;
                donhang.SDTLienLac = user_login.NumberPhone;
                donhang.DiaChiGiaoHang = user_login.Address;    
            }
            return View("Order", donhang);
        }
        public ActionResult OrderAdd(ShopingCart shop_cart,string ngayhoanthanh)
        {
            shop_cart.NgayHoanThanh = DateTime.Parse(ngayhoanthanh);
            shop_cart.listItem = ((ShopingCart)Session["DonHang"]).listItem;
            OrderDao order_dao = new OrderDao();

            int x = shop_cart.listItem.Count();
            order_dao.Add(shop_cart);
            Session["DonHang"] = null;
            ViewBag.nhon = ngayhoanthanh;
            ViewBag.x = x;
            return View("test", shop_cart);
        }
	}
}