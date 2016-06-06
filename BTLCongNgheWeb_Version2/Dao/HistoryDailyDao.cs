using BTLCongNgheWeb_Version2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}