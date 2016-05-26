namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            CF_Orders_Products = new HashSet<CF_Orders_Products>();
        }

        public int ID { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(50)]
        public string SDTLienLac { get; set; }

        [StringLength(500)]
        public string DiaChiGiaoHang { get; set; }

        public DateTime? NgayNhanYeuCau { get; set; }

        public DateTime? NgayHoanThanh { get; set; }

        public bool? GiaoHang { get; set; }

        public bool? ThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CF_Orders_Products> CF_Orders_Products { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
