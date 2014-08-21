using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
namespace App.IDAL
{
    public interface IAccountRepository
    {
        SysUser Login(string username, string pwd);
    }
}
