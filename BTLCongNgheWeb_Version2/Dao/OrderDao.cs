﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class OrderDao
    {
        MyClassDbContent db;
        public OrderDao()
        {
            db = new MyClassDbContent();
        }
        public IQueryable<Order> Orders()
        {
            //get { return db.Offices; }
            return db.Orders;
        }
        public IQueryable<Order> ListOrder()
        {
            var res = (from s in db.Orders
                       select s);
            return res;
        }
        public int CountOrder()
        {
            int res = db.Orders.Count();
            return res;
        }
        public List<Order> ListOrder_Paging(int RequiredPage,int RecordsPerPage)
        {
            object[] SqlParams = 
            {
                new SqlParameter("@RequiredPage",RequiredPage),
                 new SqlParameter("@RecordsPerPage",RecordsPerPage)
            };
            var result = db.Database.SqlQuery<Order>("Order_GetPage @RequiredPage,@RecordsPerPage", SqlParams).ToList<Order>();
            return result;
        }
        public Order FindOrderByID(int id)
        {
            var res = db.Orders.Find(id);
            return res;
        }
        public IQueryable<CF_Orders_Products> ListOrderItem(int id)
        {
            var res = (from s in db.CF_Orders_Products
                       where s.OrderID == id
                       select s);
            return res;
        }
        public void DeleteOrder(int ID)
        {
            var cf = (from table in db.CF_Orders_Products
                      where table.ProductID == ID
                      select table);
            foreach (var mem in cf)
            {
                db.CF_Orders_Products.Remove(mem);
            }
            Order order = db.Orders.Find(ID);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            db.SaveChanges();
        }
        public void DeliveryConfirmation(int ID)
        {
            Order p = db.Orders.Find(ID);
            p.GiaoHang = true;
            db.SaveChanges();
        }
        public void PaymentConfirmation(int ID)
        {
            Order p = db.Orders.Find(ID);
            p.ThanhToan = true;
            db.SaveChanges();
        }
    }
}