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
