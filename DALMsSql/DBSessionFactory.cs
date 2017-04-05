using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using System.Runtime.Remoting.Messaging;

namespace DALMsSql
{
    public class DBSessionFactory : IDBSessionFactory
    {
        public IDBSession GetDBSession()
        {
            IDBSession dbSession = CallContext.GetData(typeof(DBSessionFactory).Name) as IDBSession;
            if (dbSession==null)
            {
                dbSession = new DBSession();
                CallContext.SetData(typeof(DBSessionFactory).Name, dbSession);
            }
            return dbSession;
        }
    }
}
