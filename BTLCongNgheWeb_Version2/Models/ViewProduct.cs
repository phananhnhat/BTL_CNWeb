using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLCongNgheWeb_Version2.Models
{
    public class ViewProduct
    {
        public int ID { get; set; }

        public string NameProduct { get; set; }

        public string FullNameProduct { get; set; }

        public int? Qty { get; set; }

        public int? Price { get; set; }

        public bool? Sale { get; set; }

        public int? PriceSale { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Maker { get; set; }

        public string Description { get; set; }

        public int? NumberView { get; set; }

        public int? NumberBuy { get; set; }

        public string Note { get; set; }

        public bool? Actives { get; set; }
        public int? CreateByEmployeeID { get; set; }
        public DateTime? CreateDate { get; set; }

        public string UrlImage { get; set; }

        public string NameCate { get; set; }
        // Thử test thay đổi
        // Thử test lần 3
        // TEst sửa lần 4
         // TEst sửa lần 5
        // sua trên máy lần 6
    }
}
