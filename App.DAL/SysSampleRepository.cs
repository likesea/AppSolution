using System;
using System.Linq;
using App.IDAL;
using App.Models;
using System.Data;
namespace App.IDAL
{
    public class SysSampleRepository:ISysSampleRepository,IDisposable
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <returns>数据列表</returns>
        public IQueryable<SysSample> GetList(DBContainer db)
        {
            IQueryable<SysSample> list = db.SysSample.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Create(SysSample entity)
        {
            DBContainer db = new DBContainer();
            
            db.SysSample.Add(entity);
            return db.SaveChanges();
            
        }
        // <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">主键ID</param>
        public int Delete(string id)
        {
            DBContainer db = new DBContainer();
                SysSample entity = db.SysSample.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysSample.Remove(entity);
                }
                return db.SaveChanges();
            
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">实体</param>
        public int Edit(SysSample entity)
        {
            DBContainer db = new DBContainer();
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //db.SysSample.Attach(entity);
            return db.SaveChanges();
            
        }
        /// <summary>
        /// 获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public SysSample GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysSample.SingleOrDefault(a => a.Id == id);
            }
        }
        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
