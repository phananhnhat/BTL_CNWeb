using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using BTLCongNgheWeb_Version2.Models;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class CustomerDao
    {
         MyClassDbContent db;
         public CustomerDao()
        {
            db = new MyClassDbContent();
        }
    }
}