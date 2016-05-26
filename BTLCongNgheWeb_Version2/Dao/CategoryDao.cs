using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class CategoryDao
    {
        MyClassDbContent db;
        public CategoryDao()
        {
            db = new MyClassDbContent();
        }
        public IQueryable<Category> ListCategory()
        {
            var res = (from s in db.Categories
                       select s);
            return res;
        }
        public IQueryable<Category> category
        {
            get { return db.Categories; }
        }

        public int InsertCategory(string name, int? position, string description, bool? Active)
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

        public void UpdateCategory(Category ca)
        {
            Category caUD = db.Categories.Find(ca.ID);
            if (caUD != null)
            {
                caUD.Name = ca.Name;
                caUD.Position = ca.Position;
                caUD.Descriptions = ca.Descriptions;
                caUD.Actives = ca.Actives;
                db.SaveChanges();
            }
        }

        public void DeleteCategory(Category ca)
        {
            Category caDL = db.Categories.Find(ca.ID);
            if (caDL != null)
            {
                db.Categories.Remove(caDL);
                db.SaveChanges();
            }
        }

        public Category FindCatById(int id)
        {
            return db.Categories.Find(id);
        }

        //public IQueryable<Category> FindCategories(int Code)
        //{
        //    var res = (from s in db.Categories
        //               where s.ProductID == Code
        //               select s);

        //    return res;
        //}
    }
}