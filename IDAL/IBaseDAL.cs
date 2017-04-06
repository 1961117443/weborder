using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IDAL
{
    public interface IBaseDAL<T> where T:class,new()
    {

        int Add(T entity);
        int Del(T entity);
        int Del(Expression<Func<T, bool>> delWhere);
        int Modify(T entity, params string[] proNames);
        int Modify(T entity, Expression<Func<T, bool>> whereLambda, params string[] propNames);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> whereLambda);
        List<T> GetList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda);
        List<T> GetPageList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda);

        List<T> GetPageList<TKey>(int pageIndex, int pageSize,ref int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda,bool isAsc);
    }
}
