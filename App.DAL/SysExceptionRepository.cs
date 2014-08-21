using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.IDAL;

namespace App.IDAL
{
    public class SysExceptionRepository:IDisposable,ISysExceptionRepository
    {
        public IQueryable<SysException> GetList(DBContainer db)
        {
            IQueryable<SysException> list = db.SysException.AsQueryable();
            return list;
        }
        public int Create(SysException entity)
        {
            using(DBContainer db = new DBContainer())
            {
                db.SysException.Add(entity);
                return db.SaveChanges();
            }
        }
        public SysException GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysException.SingleOrDefault(a => a.Id == id);
            }
        }
        public void Dispose()
        {

        }
    }
}
