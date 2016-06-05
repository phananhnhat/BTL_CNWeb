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
        public int InsertCustomer(Customer customer)
         {
             object[] SqlParams = 
            {
                new SqlParameter("@Name",customer.Name),
                new SqlParameter("@NumberPhone",customer.NumberPhone),
                new SqlParameter("@Address",customer.Address),
                new SqlParameter("@Email",customer.Email),
                new SqlParameter("@Login",customer.Login),
                new SqlParameter("@Password",customer.Password)
            };
             int result = db.Database.SqlQuery<int>("Customer_Add", SqlParams).SingleOrDefault();
             return result;
         }
    }
}