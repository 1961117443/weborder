using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBLL;
using System.Data.Entity;
using System.Linq.Expressions;
using IDAL;

namespace BLLMsSql
{
    public class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        protected IBaseDAL<T> iDAL;
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

        public List<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return iDAL.GetListBy<TKey>(whereLambda, orderLambda);
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
    }
}
