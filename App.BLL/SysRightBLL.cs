using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.BLL.Core;
using App.IBLL;
using Microsoft.Practices.Unity;
using App.IDAL;
using App.Models.Sys;
using App.Common;
using App.Models;
using System.Transactions;

namespace App.BLL
{
    public class SysRightBLL : BaseBLL, ISysRightBLL
    {
        [Dependency]
        public ISysRightRepository sysRightRepository { get; set; }
        public int UpdateRight(SysRightOperateModel model)
        {
            return sysRightRepository.UpdateRight(model);
        }
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return sysRightRepository.GetRightByRoleAndModule(roleId, moduleId);
        }
 
    }
}
