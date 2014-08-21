using System;
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
    }
}