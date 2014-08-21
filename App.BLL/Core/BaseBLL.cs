using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
namespace App.BLL.Core
{
    public class BaseBLL : IDisposable
    {
        protected DBContainer db = new DBContainer();
        public void Dispose()
        {
            if(db!=null)
            {
                db.Dispose();
            }
        }
    }
}
