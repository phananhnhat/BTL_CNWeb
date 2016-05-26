using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Models;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class ProductDao
    {
        MyClassDbContent db;
        public ProductDao()
        {
            db = new MyClassDbContent();
        }
        public string GetNameProductByID(int id)
        {
            Product product = db.Products.Find(id);
            return product.NameProduct;
        }
        public IQueryable<CF_Products_Categories> ListProductByCategoryID(int id)
        {
            var res = (from s in db.CF_Products_Categories
                       where s.CategoriesID == id
                       select s);
            return res;
        }
        public IQueryable<Product> ListProduct()
        {
            var res = (from s in db.Products
                       select s);
            return res;
        }

        public IQueryable<Product> Product
        {
            get { return db.Products; }
        }
        public IEnumerable<Product> ListProduct1()
        {
            var res = (from s in db.Products
                       select s);
            return res;
        }
        public int InsertProduct(string NameProduct, string FullNameProduct, int? Qty, int? Price, bool? News, bool? Sale,
                                int? PriceSale, string Color, string Size, string Maker, string Description, string Note,
                                bool? Active, int? CreateByUserID, string[] list_Category, string UrlImage)
        {
            Product p = new Product();
            p.NameProduct = NameProduct;
            p.FullNameProduct = FullNameProduct;
            p.Qty = Qty;
            p.Price = Price;
            p.News = News;
            p.Sale = Sale;
            p.PriceSale = PriceSale;
            p.Color = Color;
            p.Size = Size;
            p.Maker = Maker;
            p.Description = Description;
            p.NumberView = 0;
            p.NumberBuy = 0;
            p.Note = Note;
            p.Actives = Active;
            p.CreateByEmployeeID = CreateByUserID;
            p.CreateDate = DateTime.Now;

            db.Products.Add(p);

            foreach (string category in list_Category)
            {
                int int_categoryid = Int32.Parse(category);
                CF_Products_Categories pc = new CF_Products_Categories();
                pc.ProductID = p.ID;
                pc.CategoriesID = int_categoryid;
                db.CF_Products_Categories.Add(pc);
            }
            db.SaveChanges();

            string[] urlImageDD = UrlImage.Split(',');

            foreach (string s in urlImageDD)
            {
                ProductImage proImage = new ProductImage();
                proImage.ProdutsID = p.ID;
                proImage.URLImage = s;
                db.ProductImages.Add(proImage);
            }
            db.SaveChanges();
            return p.ID;
        }
        public void UpdateProduct(Product p, string[] list_Category, string UrlImage)
        {
            Product product = db.Products.Find(p.ID);
            if (product != null)
            {
                product.NameProduct = p.NameProduct;
                product.FullNameProduct = p.FullNameProduct;
                product.Price = p.Price;
                product.News = p.News;
                product.Sale = p.Sale;
                product.PriceSale = p.PriceSale;
                product.Color = p.Color;
                product.Size = p.Size;
                product.Maker = p.Maker;
                product.Description = p.Description;
                product.Note = p.Note;
                product.Actives = p.Actives;

                db.SaveChanges();


                db.Database.ExecuteSqlCommand("DeleteCF_Products_Categories @ProductID", new SqlParameter("@ProductID", p.ID));
                db.Database.ExecuteSqlCommand("exec DeleteProductImages @ProductID", new SqlParameter("@ProductID", p.ID));

                foreach (string category in list_Category)
                {
                    int int_categoryid = Int32.Parse(category);
                    CF_Products_Categories pc = new CF_Products_Categories();
                    pc.ProductID = p.ID;
                    pc.CategoriesID = int_categoryid;
                    db.CF_Products_Categories.Add(pc);
                }

                string[] urlImageDD = UrlImage.Split(',');

                foreach (string s in urlImageDD)
                {
                    ProductImage proImage = new ProductImage();
                    proImage.ProdutsID = p.ID;
                    proImage.URLImage = s;
                    db.ProductImages.Add(proImage);
                }

                db.SaveChanges();
            }
        }
        public void DeleteProduct(Product p)
        {
            Product pro = db.Products.Find(p.ID);

            if (pro != null)
            {
                db.Database.ExecuteSqlCommand("DeleteProduct @ID", new SqlParameter("@ID", p.ID));
            }
        }
        public Product FindProductByICode(int Code)
        {
            return db.Products.Find(Code);
        }
        public IQueryable<CF_Products_Categories> Find_CF_Product_Categories(int Code)
        {
            var res = (from s in db.CF_Products_Categories
                       where s.ProductID == Code
                       select s);

            return res;
        }

        public List<ViewProduct> ListViewProduct(int number)
        {
            var res = db.Database.SqlQuery<ViewProduct>("exec ViewProduct @top", new SqlParameter("@top", number)).ToList();
            return res;
        }

        public List<ViewProduct> ListProductByCategory(int id)
        {
            var res = db.Database.SqlQuery<ViewProduct>("exec FindProductByCategory @ID", new SqlParameter("@ID", id)).ToList();
            return res;
        }
    }
}