using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaggerNamespace.Model;

namespace TaggerNamespace
{
    public class ExpressionBuilder
    {
        private static ParameterExpression peItem = Expression.Parameter(typeof(Item), "i");
        private static ParameterExpression peTag = Expression.Parameter(typeof(Tag), "t");
        private static MemberExpression peTags = Expression.Property(peItem, "Tags");

        public static Expression<Func<Item, bool>> BuildExpression(string query)
        {
            var nameExp = GetTagExp(query);

            var exp = Expression.And(CallMethod("Any", null), nameExp);
            return Expression.Lambda<Func<Item, bool>>(exp, peItem);
        }

        private static Expression GetTagExp(string tag)
        {
            var left = Expression.Property(peTag, "Name");
            Expression exp, right;
            if (tag[0] == '!')
            {
                right = Expression.Constant(tag.Substring(1));
                exp = Expression.Lambda<Func<Tag, bool>>(Expression.NotEqual(left, right), peTag);
                return CallMethod("All", exp);
            }
            else
            {
                right = Expression.Constant(tag);
                exp = Expression.Lambda<Func<Tag, bool>>(Expression.Equal(left, right), peTag);
                return CallMethod("Any", exp);
            }
        }

        private static MethodBase GetGenericMethod(Type type, string name, Type[] typeArgs,
            Type[] argTypes, BindingFlags flags)
        {
            int typeArity = typeArgs.Length;
            var methods = type.GetMethods()
                .Where(m => m.Name == name)
                .Where(m => m.GetGenericArguments().Length == typeArity)
                .Select(m => m.MakeGenericMethod(typeArgs));

            return Type.DefaultBinder.SelectMethod(flags, methods.ToArray(), argTypes, null);
        }

        private static Expression CallMethod(string methodName, Expression predicate)
        {
            Type elemType = typeof(IEnumerable<Tag>).GetGenericArguments()[0];
            Type[] argTypes;

            if (predicate != null)
            {
                Type predType = typeof(Func<,>).MakeGenericType(elemType, typeof(bool));
                argTypes = new[] { typeof(IEnumerable<Tag>), predType };
            }
            else
            {
                argTypes = new[] { typeof(IEnumerable<Tag>) };
            }

            // Enumerable.Any<T>(IEnumerable<T>, Func<T,bool>)
            MethodInfo anyMethod = (MethodInfo)
                GetGenericMethod(typeof(Enumerable), methodName, new[] { elemType },
                    argTypes , BindingFlags.Static);

            if (predicate != null)
                return Expression.Call(anyMethod, peTags, predicate);
            return Expression.Call(anyMethod, peTags);
        }
    }
}
