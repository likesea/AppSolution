using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models.Sys;
using App.Common;
using App.Models;

namespace App.IBLL
{
    public interface ISysUserBLL
    {
        List<permModel> GetPermission(string accountid, string controller);
    }
}
