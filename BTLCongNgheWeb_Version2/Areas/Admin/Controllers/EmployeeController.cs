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
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        //public ActionResult Index()
        //{
        //    return View("List");
        //}
        public ActionResult List(int page)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 13) == true)
                {
                    EmployeeDao employee_dao = new EmployeeDao();
                    IEnumerable<Employee> list = employee_dao.ListEmployee_GetPage(page, 10);
                    ViewBag.Count = employee_dao.CountEmployee();
                    ViewBag.RequiredPage = page;
                    return View("List", list);
                }
                else return RedirectToAction("Error", "Error");
            }
            else
            {
                return RedirectToAction("Index", "Login", new {Area = "" });
            }
        }
        //public ActionResult List1(string status)
        //{
        //    EmployeeDao employee_dao = new EmployeeDao();
        //    IEnumerable<Employee> list = employee_dao.ListEmployee();
        //    ViewBag.ida = status;
        //    return View("List", list);
        //}
        [HttpPost]
        public ActionResult List(string a, string b)
        {
            EmployeeDao my = new EmployeeDao();
            IQueryable<Employee> list = my.ListEmployee();
            return View("List", list);
        }
        public ActionResult Details(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 15) == true)
                {
                    EmployeeDao my = new EmployeeDao();
                    Employee employee = my.FindEmployeeByID(id);
                    return View("Details", employee);
                }
                else return RedirectToAction("Error", "Error");   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult Add()
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 14) == true)
                {
                    return View("Add");
                }
                else return RedirectToAction("Error", "Error");   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult Add1()
        {
            return View();
        }
        public ActionResult AddAction(Employee employee_new, string Xacnhan)
        {
            if (employee_new.Password == Xacnhan)
            {
                EmployeeDao employee_dao = new EmployeeDao();
                employee_new.CreateDate = DateTime.Now;
                //  employee_new.CreateByID = 3;
                employee_dao.InsertEmpoyee(employee_new);
                // pDao.InsertProduct();
                //foreach (string category in Category)
                //{
                //    int int_categoryid = Int32.Parse(category);

                //}
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("loimatkhauxacnhan", "Mật khẩu xác nhận không khớp");
                return RedirectToAction("Add");
            }

        }
        public ActionResult Edit(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 15) == true)
                {
                    EmployeeDao my = new EmployeeDao();
                    Employee employee = my.FindEmployeeByID(id);
                    return View("Edit", employee);
                }
                else return RedirectToAction("Error", "Error");   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult EditAction(Employee employee_edit)
        {
            EmployeeDao dao = new EmployeeDao();
            int k = dao.UpdateEmployee(employee_edit);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 16) == true)
                {
                    EmployeeDao dao = new EmployeeDao();
                    dao.DeleteEmployee(id);
                    return RedirectToAction("List");
                }
                else return RedirectToAction("Error", "Error");   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
	}
}