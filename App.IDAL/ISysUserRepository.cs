using App.Models;
using System.Linq;
namespace App.IDAL
{
    public interface ISysUserRepository
    {
        IQueryable<SysUser> GetList(DBContainer db);
        int Create(SysUser entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysUser entity);
        SysUser GetById(string id);
        bool IsExist(string id);
    }
}