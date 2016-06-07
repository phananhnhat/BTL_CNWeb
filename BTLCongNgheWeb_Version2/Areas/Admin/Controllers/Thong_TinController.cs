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
    public class Thong_TinController : Controller
    {
        //
        // GET: /Admin/Thong_Tin/
        public ActionResult List()
        {
            Thong_tin_Dao p = new Thong_tin_Dao();

            IQueryable<Employee> a = p.ListKhohang();

            return View(a);
        }
        public ActionResult Detail()
        {
            UserLogin login = (UserLogin)Session["UserLogin"];
            Thong_tin_Dao em_dao = new Thong_tin_Dao();
            Employee employee = em_dao.FindCatById(login.ID);
            return View("Detail", employee);
        }
        public ActionResult Edit(int id)
        {
            Thong_tin_Dao pDao = new Thong_tin_Dao();
            Employee p = pDao.FindCatById(id);
            return View(p);
        }
        public ActionResult Update(Employee employee_new)
        {
            Thong_tin_Dao pDao = new Thong_tin_Dao();
            pDao.Update(employee_new);
            return RedirectToAction("Detail", "Thong_Tin");
        } 
	}
}