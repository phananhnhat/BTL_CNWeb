using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLCongNgheWeb_Version2.Models
{
    public class UserLogin
    {
        public int Type { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public int GroupEmployeeID { get; set; }
    }
}