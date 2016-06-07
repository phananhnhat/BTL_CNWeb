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
        public ActionResult HomePage()
        {
            ProductDao iDao = new ProductDao();
            List<ViewProduct> listImage = iDao.ListViewProduct(6);
            ViewBag.ViewNewsProduct = listImage;

            return View();
        }
        public static int _productID;
        public ActionResult Detail(int id)
        {
            _productID = id;
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

            CommentDao cmDao = new CommentDao();
            List<ViewComment> listComment = cmDao.ListComment(id);
            ViewBag.Comment = listComment;

            return View(p);
        }

        public ActionResult ListProductByCategory(int id, int soluong)
        {
            ViewBag.IDCategoryTEST = id;
            ViewBag.SoLuong = soluong;
            //int number = 6 * ViewBag.intI;
            CategoryDao cDao = new CategoryDao();
            Category c = cDao.FindCatById(id);
            ViewBag.NameCategory = c.Name;

            ProductDao pDao2 = new ProductDao();
            List<ViewProduct> vp = pDao2.ListProductByCategory(ViewBag.IDCategoryTEST, ViewBag.SoLuong);
            List<CountProductByCategory> cpbc = pDao2.CountProductByCategory(ViewBag.IDCategoryTEST);
            var bbb = cpbc[0].Counts.ToString();
            ViewBag.CountMaxProduct = int.Parse(bbb);
            return View(vp);
        }
        public ActionResult Order()
        {
            CustomerDao cus_dao = new CustomerDao();
            ShopingCart donhang = new ShopingCart();
            donhang = (ShopingCart)Session["DonHang"];
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
        public ActionResult AddCommentAction(int ProductIID, string ContentAddComment)
        {
            int CustomersID = 1;
            CommentDao pDao = new CommentDao();
            pDao.InsertComment(ProductIID, CustomersID, ContentAddComment);
            string url = "/HomePage/Detail/" + ProductIID.ToString();
            return Redirect(url);
        }
        public ActionResult UpdateCommentAction(int IDComment, int ProductIID, string ContentComment_A)
        {
            int CustomersID = 1;
            CommentDao pDao = new CommentDao();

            pDao.UpdateComment(IDComment, ProductIID, CustomersID, ContentComment_A);
            string url = "/HomePage/Detail/" + ProductIID.ToString();
            return Redirect(url);
        }
        public ActionResult DeleteCommentAction(int id)
        {
            CommentDao cmDao = new CommentDao();
            Comment cm = cmDao.FindCommentById(id);
            cmDao.DeleteComment(cm);
            string url = "/HomePage/Detail/" + _productID.ToString();
            return Redirect(url);
        }
        public ActionResult AddOrder(int id)
        {
            if (Session["DonHang"] == null)
            {
                ShopingCart shop = new ShopingCart();
                ProductDao pro_dao = new ProductDao();
                Product pro = pro_dao.FindProductByICode(id);
                shop.AddCard(new CardItem(id, pro.NameProduct, 1, (int)pro.Price));
                Session["DonHang"] = shop;
            }
            else
            {
                ShopingCart shop = (ShopingCart)Session["DonHang"];
                ProductDao pro_dao = new ProductDao();
                Product pro = pro_dao.FindProductByICode(id);
                shop.AddCard(new CardItem(id, pro.NameProduct, 1, (int)pro.Price));
                Session["DonHang"] = shop;
            }
            return RedirectToAction("Order","HomePage");
        }
        public ActionResult DeleteOrderItem(int id)
        {
            ShopingCart shop = (ShopingCart)Session["DonHang"];
            ProductDao pro_dao = new ProductDao();
            Product pro = pro_dao.FindProductByICode(id);
            shop.DeleteCard(id);
            Session["DonHang"] = shop;
            return RedirectToAction("Order", "HomePage");
        }
	}
}