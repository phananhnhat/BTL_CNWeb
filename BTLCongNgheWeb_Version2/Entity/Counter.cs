namespace BTLCongNgheWeb_Version2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Counter")]
    public partial class Counter
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAccess { get; set; }

        public int? Number { get; set; }
    }
}
