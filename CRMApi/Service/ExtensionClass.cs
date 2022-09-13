using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace CRMApi.Service
{
    /// <summary>
    /// 静态拓展方法，原因：静态方法不能放在Service中
    /// </summary>
    public static class ExtensionClass
    {
        /// <summary>
        /// 多个OrderBy用逗号隔开,属性前面带-号表示反序排序，exp:"name,-createtime"
        /// </summary>
        /// <typeparam name="T">类名</typeparam>
        /// <param name="query">查询集合</param>
        /// <param name="name">排序的属性，反序用-号表示</param>
        /// <returns>查询集合</returns>
        public static IQueryable<T> OrderByBatch<T>(this IQueryable<T> query, string name)
        {
            var index = 0;
            var a = name.Split(',');
            foreach (var item in a)
            {
                var m = index++ > 0 ? "ThenBy" : "OrderBy";
                if (item.StartsWith("-"))
                {
                    m += "Descending";
                    name = item.Substring(1);
                }
                else
                {
                    name = item;
                }
                name = name.Trim();

                var propInfo = GetPropertyInfo<T>(typeof(T), name);
                var expr = GetOrderExpression<T>(typeof(T), propInfo);
                var method = typeof(Queryable).GetMethods().FirstOrDefault(mt => mt.Name == m && mt.GetParameters().Length == 2);
                var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
                query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
            }
            return query;
        }

        /// <summary>
        /// 获取到类中某个名称的属性信息
        /// </summary>
        /// <param name="objType">实体类</param>
        /// <param name="name">属性名称</param>
        /// <returns>属性信息</returns>
        public static PropertyInfo GetPropertyInfo<T>(Type objType, string name)
        {
            var properties = objType.GetProperties();
            var matchedProperty = properties.FirstOrDefault(p => p.Name == name);
            if (matchedProperty == null)
            {
                throw new ArgumentException("name");
            }

            return matchedProperty;
        }

        /// <summary>
        /// 获取到排序信息
        /// </summary>
        /// <param name="objType">实体类</param>
        /// <param name="pi">属性信息</param>
        /// <returns>排序信息</returns>
        public static LambdaExpression GetOrderExpression<T>(Type objType, PropertyInfo pi)
        {
            var paramExpr = Expression.Parameter(objType);
            var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
            var expr = Expression.Lambda(propAccess, paramExpr);
            return expr;
        }


    }
}
