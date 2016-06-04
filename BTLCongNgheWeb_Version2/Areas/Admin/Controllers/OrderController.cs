using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Models;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int RequiredPage)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 9) == true)
                {
                    //OrderDao order_dao = new OrderDao();
                    //IEnumerable<Order> list = order_dao.ListOrder();
                    //return View("List", list);
                    OrderDao order_dao = new OrderDao();
                    IEnumerable<Order> list = order_dao.ListOrder_Paging(RequiredPage, 7);
                    ViewBag.Count = order_dao.CountOrder();
                    ViewBag.RequiredPage = RequiredPage;
                    return View("List", list);
                }
                else return RedirectToAction("Error", "Error");   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        //[HttpPost]
        //public ActionResult List(int RecordsPerPage)
        //{
        //    OrderDao order_dao = new OrderDao();
        //    IEnumerable<Order> list = order_dao.ListOrder_Paging(5, RecordsPerPage);
        //    return View("List", list);
        //}
        public ActionResult Details(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 10) == true)
                {
                    OrderDao order_dao = new OrderDao();
                    Order order = order_dao.FindOrderByID(id); // Cái này gửi sang cũng chẳng để làm gì , phương án cũ , ko dùng
                    ViewBag.OrderItem = order_dao.ListOrderItem(id);
                    return View("Details", order);
                }
                else return RedirectToAction("Error", "Error");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }   
        }
        public ActionResult Delete(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 12) == true)
                {
                    OrderDao order_dao = new OrderDao();
                    order_dao.DeleteOrder(id);
                    return RedirectToAction("List", new { RequiredPage = 1 });
                }
                else return RedirectToAction("Error", "Error");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }      
        }
        public ActionResult Edit(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 10) == true)
                {
                    OrderDao order_dao = new OrderDao();
                    ViewBag.OrderItem = order_dao.ListOrderItem(id);
                    return View();
                }
                else return RedirectToAction("Error", "Error"); 
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }   
        }
        public ActionResult EditAction(int id) // Chưa làm vì ko biết làm những cái gì
        {
            OrderDao order_dao = new OrderDao();
            ViewBag.OrderItem = order_dao.ListOrderItem(id);
            return View();
        }
        public ActionResult DeliveryConfirmation(int id)
        {
            OrderDao order_dao =new OrderDao();
            order_dao.DeliveryConfirmation(id);
            return RedirectToAction("Details", "Order", new { id = id });
        }
        public ActionResult PaymentConfirmation(int id)
        {
            OrderDao order_dao =new OrderDao();
            order_dao.PaymentConfirmation(id);
            return RedirectToAction("Details", "Order", new { id = id });
        }
	}
}