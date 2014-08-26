using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models.Sys;
using App.Common;
using App.Models;

namespace App.IBLL
{
    public interface ISysRightBLL
    {
        //更新
        int UpdateRight(SysRightOperateModel model);
        //按选择的角色及模块加载模块的权限项
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);
    }
}
