using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
using BTLCongNgheWeb_Version2.Dao;
using System.Data.SqlClient;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class EmployeeDao
    {
        MyClassDbContent db;
        public EmployeeDao()
        {
            db = new MyClassDbContent();
        }
        public int InsertEmpoyee(Employee employee)
        {
            //  Employee employee = new Employee();
            db.Employees.Add(employee);
            db.SaveChanges();
            return employee.ID;
        }
        public IQueryable<Employee> Employees()
        {
            //get { return db.Offices; }
            return db.Employees;
        }
        public IQueryable<Employee> ListEmployee()
        {
            var res = (from s in db.Employees
                       select s);
            return res;
        }
        public int UpdateEmployee(Employee employee_new)
        {
            Employee employee = db.Employees.Find(employee_new.ID);
            if (employee != null)
            {
                employee.Name = employee_new.Name;
                employee.Address = employee_new.Address;
                employee.NumberPhone = employee_new.NumberPhone;
                employee.Email = employee_new.Email;
                employee.GroupEmployee = employee_new.GroupEmployee;
                db.SaveChanges();
                return 1;
            }
            else return 0;
            //object[] SqlParams = 
            //{
            //    new SqlParameter("@ID",off.ID),
            //     new SqlParameter("@Name",off.Name),
            //     new SqlParameter("@Address",off.Address),
            //     new SqlParameter("@NumberPhone",off.NumberPhone),
            //     new SqlParameter("@Email",off.Email),
            //     new SqlParameter("@GroupEmployee",off.GroupEmployee),
            //};
            //db.Database.ExecuteSqlCommand("UpdateEmployee @ID,@Name,@Address,@NumberPhone,@Email,@GroupEmployee", SqlParams);
            //return 1;
        }
        public void DeleteEmployee(int ID)
        {
            Employee office = db.Employees.Find(ID);
            if (office != null)
            {
                db.Employees.Remove(office);
                db.SaveChanges();
            }
        }
        public Employee FindEmployeeByID(int id)
        {
            return db.Employees.Find(id);
        }
        public string GetNameByID(int id)
        {
            return db.Employees.Find(id).Name;
        }
        public int GetIDByLogin(string login)
        {
            //var id = (from s in db.Employees     // Không thích sử dụng Procedure thì dùng cái này
            //          where s.Login == login
            //          select s.ID);
            object[] SqlParams = 
            {
                new SqlParameter("@Login",login)
            };

            int result = db.Database.SqlQuery<int>("GetIDByEmployeeLogin @Login", SqlParams).SingleOrDefault();
            return result;
        }
        public int GetGroupEmployeeIDByLogin(string login)
        {
            var group_employeeid = (from s in db.Employees     // Không thích sử dụng Procedure thì dùng cái này
                      where s.Login == login
                      select s.GroupEmployee);
            int id = 0;
            foreach (int item in group_employeeid)
            {
                id = item;
            }
            return id;
        }
        //public int[] GetAccessByLogin(string login)  // Cái này lại có cách dùng khác 
        //{
        //    IEnumerable<int> id_list = (from s in db.Employees
        //                              where s.Login == login
        //                              select s.ID);
        //    int id = 0;
        //    foreach(int item in id_list)
        //    {
        //        id = item;
        //    };
        //    var access = (from s in db.Authorizations
        //                  where s.Login == login
        //                  select s.ID);
        //    object[] SqlParams = 
        //    {
        //        new SqlParameter("@Login",login)
        //    };

        //    int result = db.Database.SqlQuery<int>("GetIDByEmployeeLogin @Login", SqlParams).SingleOrDefault();
        //    return result;
        //}
        public int Login(string login, string pass) // Thừa , vì đã chuyển sang LoginDao
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