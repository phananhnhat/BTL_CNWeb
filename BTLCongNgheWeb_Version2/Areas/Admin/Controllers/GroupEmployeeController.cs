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
    public class GroupEmployeeController : Controller
    {
        //
        // GET: /GroupEmployee/
        public ActionResult List(int page)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 17) == true)
                {
                    GroupEmployeeDao groupemployee_dao = new GroupEmployeeDao();
                    IEnumerable<GroupEmployee> list = groupemployee_dao.ListEmployee_GetPage(page, 10);
                    ViewBag.Count = groupemployee_dao.CountOrder();
                    ViewBag.RequiredPage = page;
                    return View("List", list);
                }
                else return RedirectToAction("Error", "Error");   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        //public ActionResult List1(int id)
        //{
        //    GroupEmployeeDao group_dao = new GroupEmployeeDao();
        //    IEnumerable<GroupEmployee> list = group_dao.List();
        //    ViewBag.ida = id + "a";
        //    return View("List", list);
        //}
        public ActionResult List1(string id)
        {
            GroupEmployeeDao group_dao = new GroupEmployeeDao();
            IEnumerable<GroupEmployee> list = group_dao.List();
            ViewBag.ida = id + "a";
            return View("List", list);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddAction(string NameGroupEmployee, string Note, bool acc1, bool acc2, bool acc3, bool acc4, bool acc5, bool acc6, bool acc7, bool acc8, bool acc9, bool acc10, bool acc11, bool acc12, bool acc13, bool acc14, bool acc15, bool acc16, bool acc17, bool acc18, bool acc19, bool acc20)
        {
            GroupEmployeeDao group_dao = new GroupEmployeeDao();
            GroupEmployee group_new = new GroupEmployee();
            group_new.GroupName = NameGroupEmployee;
            group_new.Note = Note;
            group_new.CreateDate = DateTime.Now;
            bool[] list_access = new bool[20];
            list_access[0] = acc1;
            list_access[1] = acc2;
            list_access[2] = acc3;
            list_access[3] = acc4;
            list_access[4] = acc5;
            list_access[5] = acc6;
            list_access[6] = acc7;
            list_access[7] = acc8;
            list_access[8] = acc9;
            list_access[9] = acc10;
            list_access[10] = acc11;
            list_access[11] = acc12;
            list_access[12] = acc13;
            list_access[13] = acc14;
            list_access[14] = acc15;
            list_access[15] = acc16;
            list_access[16] = acc17;
            list_access[17] = acc18;
            list_access[18] = acc19;
            list_access[19] = acc20;
            group_dao.InsertGroupEmployee(group_new, list_access);
            // return RedirectToAction("List1", "GroupEmployee", new { id = bcbcb });
            return RedirectToAction("List", "GroupEmployee");

        }
        public ActionResult Edit(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 19) == true)
                {
                    GroupEmployeeDao dao = new GroupEmployeeDao();
                    GroupEmployee employee_edit = dao.FindGroupEmployeeByID(id);
                    IEnumerable<Authorization> list_access= dao.ListAuthorization(id);
                    ViewBag.ListAuthorization = list_access;
                    return View("Edit", employee_edit);
                }
                else return RedirectToAction("Error", "Error"); 
   
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult EditAction(GroupEmployee group_edit, bool acc1, bool acc2, bool acc3, bool acc4, bool acc5, bool acc6, bool acc7, bool acc8, bool acc9, bool acc10, bool acc11, bool acc12, bool acc13, bool acc14, bool acc15, bool acc16, bool acc17, bool acc18, bool acc19, bool acc20)
        {
            GroupEmployeeDao group_dao = new GroupEmployeeDao();
            //GroupEmployee group_new = new GroupEmployee();
            //group_new.GroupName = NameGroupEmployee;
            //group_new.Note = Note;
            bool[] list_access = new bool[20];
            list_access[0] = acc1;
            list_access[1] = acc2;
            list_access[2] = acc3;
            list_access[3] = acc4;
            list_access[4] = acc5;
            list_access[5] = acc6;
            list_access[6] = acc7;
            list_access[7] = acc8;
            list_access[8] = acc9;
            list_access[9] = acc10;
            list_access[10] = acc11;
            list_access[11] = acc12;
            list_access[12] = acc13;
            list_access[13] = acc14;
            list_access[14] = acc15;
            list_access[15] = acc16;
            list_access[16] = acc17;
            list_access[17] = acc18;
            list_access[18] = acc19;
            list_access[19] = acc20;
            group_dao.UpdateGroupEmployee(group_edit, list_access);
            // return RedirectToAction("List1", "GroupEmployee", new { id = bcbcb });
            return RedirectToAction("List", "GroupEmployee");

        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult TestAction(FormContext form1, FormCollection form)
        {
            //string test = form1[]
            //form[]
            //string test1 = form["test1"];
            // return RedirectToAction("List1", "GroupEmployee", new { id = test + test1 });
            return View();
        }
        public ActionResult Details(int id)
        {
            if (Session["UserLogin"] != null)
            {
                UserLogin em = (UserLogin)Session["UserLogin"];
                AuthorizationDao au = new AuthorizationDao();
                if (au.CheckAccess(em.GroupEmployeeID, 19) == true)
                {
                    GroupEmployeeDao my = new GroupEmployeeDao();
                    GroupEmployee employee = my.FindGroupEmployeeByID(id);
                    return View("Details", employee);
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
                if (au.CheckAccess(em.GroupEmployeeID, 20) == true)
                {
                    GroupEmployeeDao dao = new GroupEmployeeDao();
                    dao.DeleteGroupEmployee(id);
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