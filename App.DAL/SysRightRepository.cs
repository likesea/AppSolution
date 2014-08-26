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
        public int UpdateRight(SysRightOperateModel model)
        {
            SysRightOperate rightOperate = new SysRightOperate();
            rightOperate.Id = model.Id;
            rightOperate.RightId = model.RightId;
            rightOperate.KeyCode = model.KeyCode;
            rightOperate.IsValid = model.IsValid;
            
            using(DBContainer db = new DBContainer())
            {
                SysRightOperate right = db.SysRightOperate.Where(a => a.Id == rightOperate.Id).FirstOrDefault();
                if(right !=null)
                {
                    right.IsValid = rightOperate.IsValid;
                }
                else
                {
                    db.SysRightOperate.Add(rightOperate);
                }
                if(db.SaveChanges()>0)
                {
                    var sysRight = (from r in db.SysRight
                                    where r.Id == rightOperate.RightId
                                    select r).First();
                    db.P_Sys_UpdateSysRightRightFlag(sysRight.ModuleId, sysRight.RoleId);
                    return 1;
                }
            }
            return 0;
        }
        //按选择的角色及模块加载模块的权限项
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<P_Sys_GetRightByRoleAndModule_Result> result = null;
            using (DBContainer db = new DBContainer())
            {
                result = db.P_Sys_GetRightByRoleAndModule(roleId, moduleId).ToList();
            }
            return result;
        }
        public void Dispose()
        { }
    }
}
