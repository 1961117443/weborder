using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common
{
    /// <summary>
    /// 存放查询的扩展方法
    /// </summary>
    public static class CollectionsExtensions
    {
        #region IEnumerable<T>扩展
        /// <summary>
        /// 集合是否为空
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="collection">要处理的集合</param>
        /// <returns>为空返回true</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }
        /// <summary>
        /// 将集合展开非别转换成字符串，再以指定的分隔符连接，拼成一个字符串返回
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="collection">要处理的集合</param>
        /// <param name="separator">分隔符</param>
        /// <returns>拼接后的字符串</returns>
        public static string ExpandAndToString<T>(this IEnumerable<T> collection,string separator)
        {
            List<T> source = collection as List<T> ?? collection.ToList();
            if (source.IsEmpty())
            {
                return null;
            }
            var result = source.Cast<object>().Aggregate<object, string>(null, (current, o) => current + string.Format("{0}{1}", o, separator));
            return result.Substring(0, result.Length - separator.Length);
        }

        public static IEnumerable<T>  WhereIf<T>(this IEnumerable<T> collection,Func<T,bool> predicate,bool condition)
        {
            return condition ? collection.Where(predicate) : collection;
        }

        #region 根据指定的条件返回集合中不重复的元素
        /// <summary>
        /// 根据指定的条件返回集合中不重复的元素
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <typeparam name="TKey">动态筛选条件类型</typeparam>
        /// <param name="collection">要操作的数据源</param>
        /// <param name="keySelector">重复数据筛选条件</param>
        /// <returns>不重复元素的集合</returns>
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> keySelector)
        {
            //取集合分组后的每组中的第一条数据，组成新的集合
            return collection.GroupBy(keySelector).Select(g => g.First());
        } 
        #endregion

        #endregion


        #region IQueryable扩展
        #region 把IQueryable<T> 集合按指定属性和排序方式进行排序
        /// <summary>
        /// 把IQueryable<T> 集合按指定属性和排序方式进行排序
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">数据集</param>
        /// <param name="propertyName">排序的属性</param>
        /// <param name="sortDirection">排序方式</param>
        /// <returns>排序后的结果</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, SortDirection sortDirection = SortDirection.Ascending)
        {
            return QueryableHelper<T>.OrderBy(source, propertyName, sortDirection);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, PropertySortCondition propertySortCondition)
        {
            return OrderBy<T>(source, propertySortCondition.PropertyName, propertySortCondition.SortDirection);
        }

        #endregion

        #region 把IOrderedQueryable<T> 集合按指定属性和排序方式进行排序
        /// <summary>
        /// 把IQueryable<T> 集合按指定属性和排序方式进行排序
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">数据集</param>
        /// <param name="propertyName">排序的属性</param>
        /// <param name="sortDirection">排序方式</param>
        /// <returns>排序后的结果</returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName, SortDirection sortDirection = SortDirection.Ascending)
        {
            return QueryableHelper<T>.ThenBy(source, propertyName, sortDirection);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, PropertySortCondition propertySortCondition)
        {
            return ThenBy<T>(source, propertySortCondition.PropertyName, propertySortCondition.SortDirection);
        }

        #endregion

        #region 分页查询
        /// <summary>
        /// 把IQueryable<T>集合按指定属性与排序方式进行排序后再按指定的条件，提取指定页码指定条目的数据
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">IQueryable<T>数据源</param>
        /// <param name="predicate">检索条件</param>
        /// <param name="pageIndex">指定页码</param>
        /// <param name="pageSize">指定每页条目</param>
        /// <param name="total">总记录数</param>
        /// <param name="sortConditons">排序条件</param>
        /// <returns>子集</returns>
        public static IQueryable<T> Where<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, int pageIndex,
            int pageSize, out int total,params PropertySortCondition[] sortConditons) where T : class, new()
        {
            //得到满足查询条件的总记录数
            total = source.Count(predicate);
            
            if (sortConditons!=null)
            { 
                //对数据源进行排序
                IOrderedQueryable<T> orderSource = null;
                for (int i = 0; i < sortConditons.Length; i++)
                {
                    orderSource = i == 0 ? source.OrderBy(sortConditons[i]) : orderSource.ThenBy(sortConditons[i]);
                }
                source = orderSource;
            }
            
            
            return source != null ? source.Where(predicate).Skip((pageIndex - 1) * pageSize).Take(pageSize) : Enumerable.Empty<T>().AsQueryable();
        }
        #endregion

        #region IQueryable<T>根据第三方条件是否为真，决定是否指定指定条件的查询
        /// <summary>
        /// 根据第三方条件是否为真，决定是否指定指定条件的查询
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要查询的数据源</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">第三方条件</param>
        /// <returns>查询结果</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        #endregion
        #endregion


    }
}
