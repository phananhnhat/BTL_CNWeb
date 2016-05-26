namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        public int ID { get; set; }

        public int? ProdutsID { get; set; }

        [StringLength(500)]
        public string URLImage { get; set; }

        public virtual Product Product { get; set; }
    }
}
