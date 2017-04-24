using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class ObjectExtendsions
    {
        #region 把对象转化为指定的类型，转化失败时返回返回指定的默认值
        /// <summary>
        /// 把对象转化为指定的类型，转化失败时返回返回指定的默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转化的原对象</param>
        /// <param name="defalutValue">转化失败时返回的默认值</param>
        /// <returns>转化后的值</returns>
        public static T CastTo<T>(this object value, T defalutValue)
        {
            object result;
            Type type = typeof(T);
            try
            {
                result = type.IsEnum ? Enum.Parse(type, value.ToString()) : Convert.ChangeType(value, type);
            }
            catch (Exception)
            {
                return defalutValue;
            }
            return (T)result;
        }
        /// <summary>
        /// 把对象转化为指定的类型，转化失败时返回返回类型的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T CastTo<T>(this object value)
        {
            object result;
            Type type = typeof(T);
            try
            {
                if (type.IsEnum)
                {
                    result = Enum.Parse(type, value.ToString());
                }
                else if (type == typeof(Guid))
                {
                    result = Guid.Parse(value.ToString());
                }
                else  
                {
                    result = Convert.ChangeType(value, type);
                }
            }
            catch (Exception)
            {
                result = default(T);
            }
            return (T)result;
        }
        #endregion
    }
}
