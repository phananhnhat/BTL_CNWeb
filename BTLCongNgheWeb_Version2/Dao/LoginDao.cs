using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class LoginDao
    {
         MyClassDbContent db;
         public LoginDao()
        {
            db = new MyClassDbContent();
        }
         public int Login(string login, string pass)
         {
             object[] SqlParams = 
            {
                new SqlParameter("@Login",login),
                 new SqlParameter("@Password",pass)
            };
             //var res = db.Database.SqlQuery<bool>("LoginEmployee @Login @Password",login,pass);

             int result = db.Database.SqlQuery<int>("Login @Login,@Password", SqlParams).SingleOrDefault();
             return result;
         }
    }
}