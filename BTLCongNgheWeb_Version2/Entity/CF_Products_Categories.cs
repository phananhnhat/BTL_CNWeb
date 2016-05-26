namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CF_Products_Categories
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? CategoriesID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}
