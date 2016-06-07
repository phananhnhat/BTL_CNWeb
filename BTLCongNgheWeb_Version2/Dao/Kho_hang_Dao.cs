using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Models;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class Kho_hang_Dao
    {
        MyClassDbContent db;
        public Kho_hang_Dao()
        {
            db = new MyClassDbContent();
        }

        //public IQueryable<Kho_hang> ListKhohang()  // ique danh sach    cate doi tuong chuyen vao
        //{
        //    var res = (from s in db.Categories select s);
        //    return res;
        //}

        public List<Kho_hang> Listkhohang()
        {
            var res = db.Database.SqlQuery<Kho_hang>("exec ListKhoHang").ToList();
            return res;
        }

        public int InsertKhohang(string name, int? position, string description, bool? Active)
        {
            Category cate = new Category();
            cate.Name = name;
            cate.Position = position;
            cate.Descriptions = description;
            cate.Actives = Active;

            db.Categories.Add(cate);
            db.SaveChanges();
            return cate.ID;
        }
    }
}