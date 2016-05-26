using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class GroupEmployeeDao
    {
        MyClassDbContent db;
        public GroupEmployeeDao()
        {
            db = new MyClassDbContent();
        }
        public GroupEmployee FindGroupEmployeeByID(int id)
        {
            return db.GroupEmployees.Find(id);
        }
        public int InsertGroupEmployee(GroupEmployee group_employee, bool[] list_access)
        {
            db.GroupEmployees.Add(group_employee);
            db.SaveChanges();
            //foreach (bool access in list_access)
            //{

            //}
            for (int i = 0; i < list_access.Length; i++)
            {
                if (list_access[i] == true)
                {
                    Authorization au = new Authorization();
                    au.AccessID = i + 1;
                    au.GroupEmployeeID = group_employee.ID;
                    db.Authorizations.Add(au);
                }
            }
            db.SaveChanges();
            return group_employee.ID;
        }
        public IQueryable<GroupEmployee> List()
        {
            var list = (from s in db.GroupEmployees
                        select s);
            //List<GroupEmployee> result = db.Database.SqlQuery<GroupEmployee>("LoginEmployee @Login @Password").ToList();
            return list;
        }
        public IQueryable<Authorization> ListAuthorization(int GroupEmloyeeID)
        {
            var list = (from s in db.Authorizations
                        where s.GroupEmployeeID == 3
                        select s);
            //List<GroupEmployee> result = db.Database.SqlQuery<GroupEmployee>("LoginEmployee @Login @Password").ToList();
            return list;
        }

        public int DeleteGroupEmployee(int id)
        {
            object[] SqlParams = 
            {
                new SqlParameter("@ID",id),
            };
            db.Database.ExecuteSqlCommand("DeleteGroupEmployee @ID", SqlParams);
            return 1;
        }
        public int UpdateGroupEmployee(GroupEmployee group_employee, bool[] list_access)
        {
            object[] SqlParams = 
            {
                new SqlParameter("@ID",group_employee.ID),
                new SqlParameter("@GroupName",group_employee.GroupName),
                new SqlParameter("@Note",group_employee.Note),
            };
            db.Database.ExecuteSqlCommand("UpdateGroupEmloyee @ID,@GroupName,@Note", SqlParams);

            for (int i = 0; i < list_access.Length; i++)
            {
                if (list_access[i] == true)
                {
                    Authorization au = new Authorization();
                    au.AccessID = i + 1;
                    au.GroupEmployeeID = group_employee.ID;
                    db.Authorizations.Add(au);
                }
            }
            db.SaveChanges();
            return group_employee.ID;
        }
    }
}