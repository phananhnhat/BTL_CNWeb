namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyClassDbContent : DbContext
    {
        public MyClassDbContent()
            : base("name=MyClassDbContent")
        {
        }
        // haizzz
        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CF_Orders_Products> CF_Orders_Products { get; set; }
        public virtual DbSet<CF_Products_Categories> CF_Products_Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Evaluate> Evaluates { get; set; }
        public virtual DbSet<GroupEmployee> GroupEmployees { get; set; }
        public virtual DbSet<History> Historys { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>()
                .HasMany(e => e.Authorizations)
                .WithRequired(e => e.Access)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CF_Products_Categories)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CategoriesID);

            modelBuilder.Entity<Customer>()
                .Property(e => e.NumberPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PasswordLevel2)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomersID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Evaluates)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomersID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.NumberPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PasswordLevel2)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.CreateByEmployeeID);

            modelBuilder.Entity<GroupEmployee>()
                .HasMany(e => e.Authorizations)
                .WithRequired(e => e.GroupEmployee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupEmployee>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.GroupEmployee1)
                .HasForeignKey(e => e.GroupEmployee);

            modelBuilder.Entity<Order>()
                .Property(e => e.SDTLienLac)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.CF_Orders_Products)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductImage>()
                .Property(e => e.URLImage)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CF_Orders_Products)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProductIID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Evaluates)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductImages)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.ProdutsID);
        }
    }
}
