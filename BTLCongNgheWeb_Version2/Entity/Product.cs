namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CF_Orders_Products = new HashSet<CF_Orders_Products>();
            CF_Products_Categories = new HashSet<CF_Products_Categories>();
            Comments = new HashSet<Comment>();
            Evaluates = new HashSet<Evaluate>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string NameProduct { get; set; }

        [StringLength(500)]
        public string FullNameProduct { get; set; }

        public int? Qty { get; set; }

        public int? Price { get; set; }

        public bool? News { get; set; }

        public bool? Sale { get; set; }

        public int? PriceSale { get; set; }

        [StringLength(60)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(50)]
        public string Maker { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? NumberView { get; set; }

        public int? NumberBuy { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public bool? Actives { get; set; }

        public int? CreateByEmployeeID { get; set; }

        public DateTime? CreateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CF_Orders_Products> CF_Orders_Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CF_Products_Categories> CF_Products_Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evaluate> Evaluates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
