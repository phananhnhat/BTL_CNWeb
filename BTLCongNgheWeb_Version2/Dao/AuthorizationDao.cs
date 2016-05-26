using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class AuthorizationDao
    {
        MyClassDbContent db;
        public AuthorizationDao()
        {
            db = new MyClassDbContent();
        }
        public int FindAuthorization(int GroupEmloyeeID, int AccessID)
        {
            Authorization au = db.Authorizations.Find(GroupEmloyeeID, AccessID);
            if (au != null)
                return 1;
            else return 0;
        }
        public bool CheckAccess(int GroupEmloyeeID, int AccessID)
        {
            Authorization au = db.Authorizations.Find(GroupEmloyeeID, AccessID);
            if (au != null)
                return true;
            else return false;
        }
    }
}