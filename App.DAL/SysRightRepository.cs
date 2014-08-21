using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.IDAL;
using App.Models;
using App.Models.Sys;

namespace App.IDAL
{
    public class SysRightRepository:ISysRightRepository,IDisposable
    {
        public List<permModel> GetPermission(string accountid,string controller)
        {
            using(DBContainer db = new DBContainer())
            {
                List<permModel> rights = (from r in db.P_Sys_GetRightOperate(accountid, controller)
                                          select new permModel
                                          {
                                              KeyCode = r.KeyCode,
                                              IsValid = r.IsValid
                                          }).ToList();
                return rights;
            }
        }
        public void Dispose()
        { }
    }
}
