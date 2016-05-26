namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            CF_Products_Categories = new HashSet<CF_Products_Categories>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Position { get; set; }

        [StringLength(500)]
        public string Descriptions { get; set; }

        public bool? Actives { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CF_Products_Categories> CF_Products_Categories { get; set; }
    }
}
