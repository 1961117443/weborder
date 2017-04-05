using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using Models;
using IDAL;

namespace DALMsSql
{
    /// <summary>
    /// 通过线程获取DbContext
    /// </summary>
    public class DBContextFactory : IDBContextFactory
    {
        public DbContext GetDBContext()
        {
            DbContext db = CallContext.GetData(typeof(DBContextFactory).Name) as DbContext;
            if (db==null)
            {
                db = new WebOrderEntities();
                CallContext.SetData(typeof(DBContextFactory).Name, db);
            }
            return db;
        }
    }
}
