using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLCongNgheWeb_Version2.Dao
{
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(int _productID, string _productName, int _qty)
        {
            ProductID = _productID;
            ProductName = _productName;
            Qty = _qty;
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
    }
}