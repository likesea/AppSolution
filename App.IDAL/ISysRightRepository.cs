﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.Models.Sys;

namespace App.IDAL
{
    public interface ISysRightRepository
    {
        List<permModel> GetPermission(string accountid, string controller);
        int UpdateRight(SysRightOperateModel model);
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);
    }
}