using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisualProgrammingUnitTesting.Common
{
    class GlobalAsserts
    {
        public static Boolean CanWrite<T, TValue>(Expression<Func<T, TValue>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string name = member.Member.Name;
            PropertyInfo property = member.Member.DeclaringType.GetProperty(name);

            return property.CanWrite;
        }

        public static Boolean CanRead<T, TValue>(Expression<Func<T, TValue>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;
            string name = member.Member.Name;
            PropertyInfo property = member.Member.DeclaringType.GetProperty(name);

            return property.CanRead;
        }
    }
}
