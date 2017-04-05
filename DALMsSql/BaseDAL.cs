using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IDAL;
using System.Data.Entity;
using Models;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace DALMsSql
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// EF上下文
        /// </summary>
        DbContext db = new DBContextFactory().GetDBContext();
           
        public int Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges();
        }

        public int Del(Expression<Func<T, bool>> delWhere)
        {
            var dbs = db.Set<T>();
            var lists= dbs.Where(delWhere);
            foreach (var item in lists)
            {
                dbs.Attach(item);
                dbs.Remove(item);
            }
            return db.SaveChanges();
        }

        public int Del(T entity)
        {
            var dbs = db.Set<T>();
            dbs.Attach(entity);
            dbs.Remove(entity);
            return db.SaveChanges();            
        }

        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return db.Set<T>().Where(whereLambda).OrderBy(orderLambda).ToList();
        }

        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            int skipCount = (pageIndex - 1) * pageSize;
            return db.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip(skipCount).Take(pageSize).ToList();
        }

        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, ref int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc)
        {
            int skipCount = (pageIndex - 1) * pageSize;
            IQueryable<T> list = null;
            if (isAsc)
            {
                list = db.Set<T>().Where(whereLambda).OrderBy(orderLambda);
            }
            else
            {
                list = db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda);
            }
            totalCount = list.Count();
            return list.Skip(skipCount).Take(pageSize).ToList();
        }

        public int Modify(T entity, Expression<Func<T, bool>> whereLambda,params string[] propNames)
        {
            IQueryable<T> modifyList = db.Set<T>().Where(whereLambda);
            Type t = typeof(T);
            var props = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            Dictionary<string, PropertyInfo> dicProps = new Dictionary<string, PropertyInfo>();
            foreach (var p in props)
            {
                if (propNames.Contains(p.Name))
                {
                    dicProps.Add(p.Name, p);
                }
            }

            foreach (var d in dicProps.Keys)
            {
                PropertyInfo propInfo = dicProps[d];
                object newValue = propInfo.GetValue(entity, null);
                foreach (var m in modifyList)
                {
                    propInfo.SetValue(m, newValue, null);
                }
            }
            return db.SaveChanges();
        }

        public int Modify(T entity, params string[] proNames)
        {
            DbEntityEntry entry = db.Entry<T>(entity);
            entry.State = EntityState.Unchanged;
            foreach (string prop in proNames)
            {
                entry.Property(prop).IsModified = true;
            }
            return db.SaveChanges();
        }
    }
}
