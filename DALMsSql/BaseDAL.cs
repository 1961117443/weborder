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
using Common.Log;
using Common;

namespace DALMsSql
{
    public class BaseDAL<T> :BaseLog<T>, IBaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// EF上下文
        /// </summary>
        DbContext db = new DBContextFactory().GetDBContext(); 

        public IQueryable<T> Entities
        {
            get
            {
               return  db.Set<T>();
            }
        }

        public int Add(T entity)
        {
            int iret = -1;
            Logger(DBAction.Add, () => {
                db.Set<T>().Add(entity);
                iret = db.SaveChanges();
            });
            return iret;
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
            int iret = -1;
            Logger(DBAction.Delete,
                () =>
                {
                    var dbs = db.Set<T>();
                    dbs.Attach(entity);
                    dbs.Remove(entity);
                    iret=db.SaveChanges();
                }
            );
            return iret;
        }

        public List<T> GetList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            IQueryable<T> list = db.Set<T>();
            if (whereLambda!=null)
            {
                list = list.Where(whereLambda);
            }
            if (orderLambda!=null)
            {
                list = list.OrderBy(orderLambda);
            }
            return list.ToList(); 
        }

        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            int skipCount = (pageIndex - 1) * pageSize;
            return db.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip(skipCount).Take(pageSize).ToList();
        }

        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, ref int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc)
        {
            int skipCount = (pageIndex - 1) * pageSize;
            //IQueryable<T> list = null;
            IQueryable<T> list = db.Set<T>();
            if (whereLambda != null)
            {
                list = list.Where(whereLambda);
            }
            if (isAsc)
            {
                 list = list.OrderBy(orderLambda);
               // list = list.Where(whereLambda).OrderBy(orderLambda);
            }
            else
            {
                list = list.OrderByDescending(orderLambda);
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
            entry.State = EntityState.Modified;
            foreach (string prop in proNames)
            {
                entry.Property(prop).IsModified = true;
            }
            return db.SaveChanges();
        }

        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda).ToList();
        }
    }
}
