using BTLCongNgheWeb_Version2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTLCongNgheWeb_Version2.Entity;
namespace BTLCongNgheWeb_Version2.Dao
{
    public class HistoryDailyDao
    {
         MyClassDbContent db;
        public HistoryDailyDao()
        {
            db = new MyClassDbContent();
        }
        public void Update()
        {
            db.Database.ExecuteSqlCommand("HistoryDailies_Update");
        }
        public IEnumerable<HistoryDaily> List()
        {
            var list = (from s in db.HistoryDailies
                        orderby s.DateAccess
                        select s);
            return list;
            //return db.HistoryDailies;
        }
    }
}