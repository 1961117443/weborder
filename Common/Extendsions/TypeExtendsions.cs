using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Common
{
    public static class TypeExtendsions
    {
        public static bool IsNumeric(this Type type)
        {
            return type == typeof(Byte)
                || type == typeof(Int16)
                || type == typeof(Int32)
                || type == typeof(Int64)
                || type == typeof(SByte)
                || type == typeof(UInt16)
                || type == typeof(UInt32)
                || type == typeof(UInt64)
                || type == typeof(Decimal)
                || type == typeof(Double)
                || type == typeof(Single);
        }

        /// <summary>
        /// 根据属性类型，转换值
        /// </summary>
        /// <param name="type">目标类型</param>
        /// <param name="value">原始值</param>
        /// <returns>目标类型的值</returns>
        public static object ChangeType(this Type type,object value)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null || string.IsNullOrEmpty(value.ToString())) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(innerType, value);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            return Convert.ChangeType(value, type);
        }

        #region 扩展 ICustomAttributeProvider
        public static T GetAttribute<T>(this ICustomAttributeProvider provider, bool inherit) where T:Attribute
        {
            return provider.GetCustomAttributes(inherit).SingleOrDefault() as T;
        } 

        public static T[] GetAttributes<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute
        {
            return provider.GetCustomAttributes(inherit).Cast<T>().ToArray();
        }

        public static bool AttributeExists<T>(this ICustomAttributeProvider provider, bool inherit) where T : Attribute
        {
            return provider.IsDefined(typeof(T), inherit);
        }

        public static string Description(this ICustomAttributeProvider provider, bool inherit=false) 
        {
            DescriptionAttribute desc= GetAttribute<DescriptionAttribute>(provider, inherit);
            return desc == null ? "" : desc.Description;
        }
        #endregion
    }
}
