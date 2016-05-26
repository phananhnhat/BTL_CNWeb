using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Admin_Catgories/
        public ActionResult List()
        {
            CategoryDao cDao = new CategoryDao();
            IQueryable<Category> c = cDao.ListCategory();
            return View("List", c);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            CategoryDao cDao = new CategoryDao();
            Category c = cDao.FindCatById(id);
            return View(c);
        }

        public ActionResult Delete(int id)
        {
            CategoryDao cDao = new CategoryDao();
            Category c = cDao.FindCatById(id);
            cDao.DeleteCategory(c);
            return RedirectToAction("List");
        }

        public ActionResult AddAction(Category c)
        {
            CategoryDao cDao = new CategoryDao();
            cDao.InsertCategory(c.Name, c.Position, c.Descriptions, c.Actives);
            return RedirectToAction("List");

        }

        public ActionResult EditAction(Category c)
        {
            CategoryDao cDao = new CategoryDao();
            cDao.UpdateCategory(c);
            return RedirectToAction("List");
        }
	}
}