using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common
{
    public class QueryableHelper<T>
    {
        /// <summary>
        /// 缓存，保存转换后的结果，方便下次直接使用
        /// </summary>
        private static readonly ConcurrentDictionary<string, LambdaExpression> Cache = new ConcurrentDictionary<string, LambdaExpression>();
        /// <summary>
        /// 把属性转换成lambda表达式
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static LambdaExpression GetLambdaExpression(string propertyName)
        {
            if (!Cache.ContainsKey(propertyName))
            {
                ParameterExpression param = Expression.Parameter(typeof(T));
                MemberExpression body = Expression.Property(param, propertyName);
                LambdaExpression keySelector = Expression.Lambda(body, param);
                Cache[propertyName] = keySelector;
            }
            return Cache[propertyName];
        }


        /// <summary>
        /// 对某个数据源按照某列，某个方向进行排序
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="sortDirection"></param>
        /// <returns>排序后的结果</returns>
        public static IOrderedQueryable<T> OrderBy(IQueryable<T> source,string propertyName,SortDirection sortDirection)
        {
            dynamic keySelector = GetLambdaExpression(propertyName);
            return sortDirection == SortDirection.Ascending ? Queryable.OrderBy(source, keySelector) : Queryable.OrderByDescending(source, keySelector);
        }

        /// <summary>
        /// 对某个排序后的数据源再按照某列，某个方向进行排序
        /// </summary>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="sortDirection"></param>
        /// <returns>排序后的结果</returns>
        public static IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> source, string propertyName, SortDirection sortDirection)
        {
            dynamic keySelector = GetLambdaExpression(propertyName);
            return sortDirection == SortDirection.Ascending ? Queryable.OrderBy(source, keySelector) : Queryable.OrderByDescending(source, keySelector);
        }

    }
}
