using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLCongNgheWeb_Version2.Models
{
    public class ViewComment
    {
        public int ID { get; set; }

        public int? ProductIID { get; set; }

        public string NameCustomer { get; set; }

        public string ContentComment { get; set; }
    }
}