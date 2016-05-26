﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Models;
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
                EmployeeDao employee_dao = new EmployeeDao();
                UserLogin userlogin = new UserLogin();
                userlogin.Type = 2;
                userlogin.ID = 10;
                userlogin.Login = name;
                userlogin.Name = "Rất tuyệt vời";
                Session["UserLogin"] = userlogin;
                return RedirectToAction("HomePage", "HomePage"); // Chức năng này chưa làm
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
        public ActionResult Success()
        {
            return View();
        }
    }
}