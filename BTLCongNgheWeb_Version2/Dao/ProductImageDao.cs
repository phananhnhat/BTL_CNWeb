using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class ProductImageDao
    {
        MyClassDbContent db;

        public ProductImageDao()
        {
            db = new MyClassDbContent();
        }

        public IQueryable<ProductImage> ListProductImage()
        {
            var res = (from s in db.ProductImages
                       select s);
            return res;
        }
        public IEnumerable<ProductImage> ListProductImage1()
        {
            var res = (from s in db.ProductImages
                       select s);
            return res;
        }
        public int InsertProductImage(int? ProdutsID, string URLImage)
        {
            ProductImage p = new ProductImage();
            p.ProdutsID = ProdutsID;
            p.URLImage = URLImage;

            db.ProductImages.Add(p);
            db.SaveChanges();

            return p.ID;
        }

        public void UpdateProductImage(ProductImage p)
        {
            ProductImage ProductImage = db.ProductImages.Find(p.ID);
            if (ProductImage != null)
            {
                ProductImage.ProdutsID = p.ProdutsID;
                ProductImage.URLImage = p.URLImage;

                db.SaveChanges();
            }
        }

        public void DeleteProductImage(ProductImage p)
        {
            ProductImage pro = db.ProductImages.Find(p.ID);
            if (pro != null)
            {
                db.ProductImages.Remove(pro);
                db.SaveChanges();
            }
        }

        public ProductImage FindProductImage(int Code)
        {
            return db.ProductImages.Find(Code);
        }

        public IQueryable<ProductImage> FindImage(int Code)
        {
            var count = db.ProductImages
            .Where(o => o.ProdutsID == Code)
            .Count();
            if (count > 0)
            {
                var res = (from s in db.ProductImages
                           where s.ProdutsID == Code
                           select s);
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}