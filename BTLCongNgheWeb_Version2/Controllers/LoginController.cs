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
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        //public ActionResult Index(string xam,int that)
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Index(string name, string password)
        {
            LoginDao login_dao = new LoginDao();
            if (login_dao.Login(name, password) == 1)
            {
                EmployeeDao employee_dao = new EmployeeDao();
                UserLogin userlogin = new UserLogin();
                userlogin.Type = 1;
                userlogin.ID = employee_dao.GetIDByLogin(name);
                userlogin.Login = name;
                userlogin.Name = employee_dao.GetNameByID(userlogin.ID);
                userlogin.GroupEmployeeID = employee_dao.GetGroupEmployeeIDByLogin(name);
                Session["UserLogin"] = userlogin;
                return RedirectToAction("Blank", "Blank", new {Area = "Admin" });
            }
            else if (login_dao.Login(name, password) == 2)
            {
                CustomerDao cus_dao = new CustomerDao();
                UserLogin userlogin = new UserLogin();
                userlogin.Type = 2;
                userlogin.ID = cus_dao.GetIDByLogin(name);
                userlogin.Login = name;
                userlogin.Name = cus_dao.GetNameByID(userlogin.ID);
                Session["UserLogin"] = userlogin;
                return RedirectToAction("HomePage", "HomePage"); 
            } else
            {
                ModelState.AddModelError("loitaikhoan", "Tài khoản hoặc mật khẩu không chính xác");
            }
            return View("Index");
        }
        public ActionResult LogOut()
        {
            Session["UserLogin"] = null;
            return RedirectToAction("HomePage", "HomePage");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult AddCustomer(Customer customer_new)
        {
            //CustomerD employee_dao = new EmployeeDao();
            // Viết code thêm tài khoản cho khách hàng vào đây
            // Test 
            CustomerDao cus_dao = new CustomerDao();
            int result = cus_dao.InsertCustomer(customer_new); // vẫn chưa biết xử lý
            return RedirectToAction("HomePage", "HomePage", new { Area = "" });
        }
        public ActionResult Success()
        {
            return View();
        }
    }
 
}