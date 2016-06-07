using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class Thong_tin_Dao
    {
        MyClassDbContent db;

        public Thong_tin_Dao()
        {
            db = new MyClassDbContent();
        }

        public IQueryable<Employee> ListKhohang()  // ique danh sach    cate doi tuong chuyen vao
        {
            var res = (from s in db.Employees select s);
            return res;
        }
        public Employee FindCatById(int id)
        {
            return db.Employees.Find(id);
        }
        public void Update(Employee employee_new)
        {
            Employee employee_old = db.Employees.Find(employee_new.ID);
            employee_old.Name = employee_new.Name;
            employee_old.Address = employee_new.Address;
            employee_old.NumberPhone = employee_new.NumberPhone;
            employee_old.Email = employee_new.Email;
            employee_old.Login = employee_new.Login;
            employee_old.GroupEmployee = employee_new.GroupEmployee;
            employee_old.Password = employee_new.Password;
            employee_old.PasswordLevel2 = employee_new.PasswordLevel2;

            db.SaveChanges();
        }
    }
}