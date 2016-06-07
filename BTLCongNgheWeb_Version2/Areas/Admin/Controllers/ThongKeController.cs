using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Entity;
namespace BTLCongNgheWeb_Version2.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        //
        // GET: /Admin/ThongKe/
        public ActionResult HistoryDaily()
        {
            HistoryDailyDao his_dao = new HistoryDailyDao();
            IEnumerable<HistoryDaily> list = his_dao.List();
            return View(list);
        }
	}
}