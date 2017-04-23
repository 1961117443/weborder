using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;
using System.Linq.Expressions;
using IDAL;
using DI;

namespace BLLMsSql
{
    public abstract class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        protected IBaseDAL<T> iDAL;

        public abstract void SetDAL();

        private IDBSession _DBSession;
        public IDBSession DBSession
        {
            get
            {
                if (_DBSession==null)
                {
                    _DBSession = SpringHelper.GetObject<IDBSessionFactory>("DBSessionFactory").GetDBSession();
                     
                }
                return _DBSession;
            }
        }

        public IQueryable<T> Entities
        {
            get
            {
               return  iDAL.Entities;
            }
        }

        public BaseBLL()
        {
            SetDAL();
        }
        public int Add(T entity)
        {
            return iDAL.Add(entity);
        }

        public int Del(Expression<Func<T, bool>> delWhere)
        {
            return iDAL.Del(delWhere);
        }

        public int Del(T entity)
        {
            return iDAL.Del(entity);
        }

        public List<T> GetList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return iDAL.GetList<TKey>(whereLambda, orderLambda);
        }

        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return iDAL.GetPageList<TKey>(pageIndex, pageSize, whereLambda, orderLambda);
        }

        public List<T> GetPageList<TKey>(int pageIndex, int pageSize, ref int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc)
        {
            return iDAL.GetPageList<TKey>(pageIndex, pageSize, ref totalCount, whereLambda, orderLambda, isAsc);
        }

        public int Modify(T entity, params string[] proNames)
        {
            return iDAL.Modify(entity, proNames);
        }

        public int Modify(T entity, Expression<Func<T, bool>> whereLambda, params string[] propNames)
        {
            return iDAL.Modify(entity, whereLambda, propNames);
        }

        public List<T> GetList()
        {
            return iDAL.GetList();
        }

        public List<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return iDAL.GetList(whereLambda);
        }
    }
}
