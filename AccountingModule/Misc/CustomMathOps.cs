using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Misc
{
    static class CustomMathOps
    {
        public static object Add(object first, object second)
        {
            if (null == first)
                return second;

            if (null == second)
                return first;

            if (first is Decimal && second is Decimal)
                return Add((Decimal)first, (Decimal)second);

            if (first is Int32 && second is Int32)
                return Add((Int32)first, (Int32)second);
            
            if (first is String && second is String)
                return Add((String)first, (String)second);

            if (first is TimeSpan && second is TimeSpan)
                return Add((TimeSpan)first, (TimeSpan)second);

            if (first is Decimal && second is Int32)
                return Add((Decimal)first, (Int32)second);

            if (first is Int32 && second is Decimal)
                return Add((Int32)first, (Decimal)second);

            if (first is Decimal && second is String)
                return Add((Decimal)first, (String)second);

            if (first is String && second is Decimal)
                return Add((String)first, (Decimal)second);

            if (first is DateTime && second is Decimal)
                return Add((DateTime)first, (Decimal)second);

            if (first is Decimal && second is DateTime)
                return Add((Decimal)first, (DateTime)second);

            if (first is Decimal && second is TimeSpan)
                return Add((Decimal)first, (TimeSpan)second);

            if (first is TimeSpan && second is Decimal)
                return Add((TimeSpan)first, (Decimal)second);

            if (first is String && second is Int32)
                return Add((String)first, (Int32)second);

            if (first is Int32 && second is String)
                return Add((Int32)first, (String)second);

            if (first is DateTime && second is Int32)
                return Add((DateTime)first, (Int32)second);

            if (first is Int32 && second is DateTime)
                return Add((Int32)first, (DateTime)second);

            if (first is TimeSpan && second is Int32)
                return Add((TimeSpan)first, (Int32)second);

            if (first is Int32 && second is TimeSpan)
                return Add((Int32)first, (TimeSpan)second);

            if (first is String && second is DateTime)
                return Add((String)first, (DateTime)second);

            if (first is DateTime && second is String)
                return Add((DateTime)first, (String)second);

            if (first is String && second is TimeSpan)
                return Add((String)first, (TimeSpan)second);

            if (first is TimeSpan && second is String)
                return Add((TimeSpan)first, (String)second);

            if (first is DateTime && second is TimeSpan)
                return Add((DateTime)first, (TimeSpan)second);

            if (first is TimeSpan && second is DateTime)
                return Add((TimeSpan)first, (DateTime)second);

            throw new AccountingModuleException("Addition can not be performed with the supplied types. Supplied types were: {0}-{1}", first.GetType().FullName, second.GetType().FullName);
        }

        public static object Multiply(object first, object second)
        {
            if (null == first)
                return second;

            if (null == second)
                return first;

            if (first is Decimal && second is Decimal)
                return Multiply((Decimal)first, (Decimal)second);

            if (first is Int32 && second is Int32)
                return Multiply((Int32)first, (Int32)second);

            if (first is Decimal && second is Int32)
                return Multiply((Decimal)first, (Int32)second);

            if (first is Int32 && second is Decimal)
                return Multiply((Int32)first, (Decimal)second);

            if (first is String && second is Int32)
                return Multiply((String)first, (Int32)second);

            if (first is Int32 && second is String)
                return Multiply((Int32)first, (String)second);

            if (first is String && second is Decimal)
                return Multiply((String)first, (Decimal)second);

            if (first is Decimal && second is String)
                return Multiply((Decimal)first, (String)second);

            throw new AccountingModuleException("Multiplication can not be performed with the supplied types. Supplied types were: {0}-{1}", first.GetType().FullName, second.GetType().FullName);
        }

        public static bool IsEqualTo(object first, object second)
        {
            if (first == null || second == null)
                return false;

            if (first is Decimal && second is Decimal)
                return IsEqualTo((Decimal)first, (Decimal)second);

            if (first is Int32 && second is Int32)
                return IsEqualTo((Int32)first, (Int32)second);

            if (first is Decimal && second is Int32)
                return IsEqualTo((Decimal)first, (Int32)second);

            if (first is Int32 && second is Decimal)
                return IsEqualTo((Int32)first, (Decimal)second);

            if (first is String && second is String)
                return IsEqualTo((String)first, (String)second);

            if (first is DateTime && second is DateTime)
                return IsEqualTo((DateTime)first, (DateTime)second);

            if (first is TimeSpan && second is TimeSpan)
                return IsEqualTo((TimeSpan)first, (TimeSpan)second);

            throw new AccountingModuleException("Supplied types are not valid for equality check. Supplied types were: {0}-{1}", first.GetType().FullName, second.GetType().FullName);
        }

        public static bool IsGreaterThan(object first, object second)
        {
            if (first == null || second == null)
                return false;

            if (first is Decimal && second is Decimal)
                return IsGreaterThan((Decimal)first, (Decimal)second);

            if (first is Int32 && second is Int32)
                return IsGreaterThan((Int32)first, (Int32)second);

            if (first is Decimal && second is Int32)
                return IsGreaterThan((Decimal)first, (Int32)second);

            if (first is Int32 && second is Decimal)
                return IsGreaterThan((Int32)first, (Decimal)second);

            if (first is DateTime && second is DateTime)
                return IsGreaterThan((DateTime)first, (DateTime)second);

            if (first is TimeSpan && second is TimeSpan)
                return IsGreaterThan((TimeSpan)first, (TimeSpan)second);

            throw new AccountingModuleException("Supplied types are not valid for greater check. Supplied types were: {0}-{1}", first.GetType().FullName, second.GetType().FullName);
        }

        public static bool IsLessThan(object first, object second)
        {
            if (first == null || second == null)
                return false;

            if (first is Decimal && second is Decimal)
                return IsLessThan((Decimal)first, (Decimal)second);

            if (first is Int32 && second is Int32)
                return IsLessThan((Int32)first, (Int32)second);

            if (first is Decimal && second is Int32)
                return IsGreaterThan((Decimal)first, (Int32)second);

            if (first is Int32 && second is Decimal)
                return IsGreaterThan((Int32)first, (Decimal)second);

            if (first is DateTime && second is DateTime)
                return IsLessThan((DateTime)first, (DateTime)second);

            if (first is TimeSpan && second is TimeSpan)
                return IsLessThan((TimeSpan)first, (TimeSpan)second);

            throw new AccountingModuleException("Supplied types are not valid for less check. Supplied types were: {0}-{1}", first.GetType().FullName, second.GetType().FullName);
        }

        private static object Add(Decimal first, Decimal second)
        {
            return first + second;
        }

        private static object Add(Int32 first, Int32 second)
        {
            return first + second;
        }

        private static object Add(String first, String second)
        {
            return first + second;
        }

        private static object Add(TimeSpan first, TimeSpan second)
        {
            return first.Add(second);
        }

        private static object Add(Decimal first, Int32 second)
        {
            return first + Convert.ToDecimal(second);
        }

        private static object Add(Int32 first, Decimal second)
        {
            return Add(second, first);
        }

        private static object Add(Decimal first, String second)
        {
            return Convert.ToString(first) + second;
        }

        private static object Add(String first, Decimal second)
        {
            return Add(second, first);
        }

        private static object Add(DateTime first, Decimal second)
        {
            return first.AddDays(Convert.ToInt32(second));
        }

        private static object Add(Decimal first, DateTime second)
        {
            return Add(second, first);
        }

        private static object Add(TimeSpan first, Decimal second)
        {
            return first.Add(TimeSpan.FromHours(Convert.ToInt32(second)));
        }

        private static object Add(Decimal first, TimeSpan second)
        {
            return Add(second, first);
        }

        private static object Add(String first, Int32 second)
        {
            return first + Convert.ToString(second);
        }

        private static object Add(Int32 first, String second)
        {
            return Add(second, first);
        }

        private static object Add(DateTime first, Int32 second)
        {
            return first.AddDays(second);
        }

        private static object Add(Int32 first, DateTime second)
        {
            return Add(second, first);
        }

        private static object Add(TimeSpan first, Int32 second)
        {
            return first.Add(TimeSpan.FromHours(second));
        }

        private static object Add(Int32 first, TimeSpan second)
        {
            return Add(second, first);
        }

        private static object Add(String first, DateTime second)
        {
            return first + Convert.ToString(second);
        }

        private static object Add(DateTime first, String second)
        {
            return Add(second, first);
        }

        private static object Add(String first, TimeSpan second)
        {
            return first + Convert.ToString(second);
        }

        private static object Add(TimeSpan first, String second)
        {
            return Add(second, first);
        }

        private static object Add(DateTime first, TimeSpan second)
        {
            return first.Add(second);
        }

        private static object Add(TimeSpan first, DateTime second)
        {
            return Add(second, first);
        }

        private static object Multiply(Decimal first, Decimal second)
        {
            return first * second;
        }

        private static object Multiply(Int32 first, Int32 second)
        {
            return first * second;
        }

        private static object Multiply(Decimal first, Int32 second)
        {
            return first * Convert.ToDecimal(second);
        }

        private static object Multiply(Int32 first, Decimal second)
        {
            return Multiply(second, first);
        }

        private static object Multiply(string first, Int32 second)
        {
            return String.Concat(Enumerable.Repeat(first, second));
        }

        private static object Multiply(Int32 first, String second)
        {
            return Multiply(second, first);
        }

        private static object Multiply(String first, Decimal second)
        {
            return Multiply(first, Convert.ToInt32(second));
        }

        private static object Multiply(Decimal first, String second)
        {
            return Multiply(second, Convert.ToInt32(first));
        }

        private static bool IsEqualTo(Decimal first, Decimal second)
        {
            return first == second;
        }

        private static bool IsEqualTo(Int32 first, Int32 second)
        {
            return first == second;
        }

        private static bool IsEqualTo(Decimal first, Int32 second)
        {
            return first == Convert.ToDecimal(second);
        }

        private static bool IsEqualTo(Int32 first, Decimal second)
        {
            return IsEqualTo(second, first);
        }

        private static bool IsEqualTo(String first, String second)
        {
            return first == second;
        }

        private static bool IsEqualTo(DateTime first, DateTime second)
        {
            return first == second;
        }

        private static bool IsEqualTo(TimeSpan first, TimeSpan second)
        {
            return first == second;
        }

        private static bool IsGreaterThan(Decimal first, Decimal second)
        {
            return first > second;
        }

        private static bool IsGreaterThan(Int32 first, Int32 second)
        {
            return first > second;
        }

        private static bool IsGreaterThan(Decimal first, Int32 second)
        {
            return first > Convert.ToDecimal(second);
        }

        private static bool IsGreaterThan(Int32 first, Decimal second)
        {
            return IsGreaterThan(second, first);
        }

        private static bool IsGreaterThan(DateTime first, DateTime second)
        {
            return first > second;
        }

        private static bool IsGreaterThan(TimeSpan first, TimeSpan second)
        {
            return first > second;
        }

        private static bool IsLessThan(Decimal first, Decimal second)
        {
            return first < second;
        }

        private static bool IsLessThan(Int32 first, Int32 second)
        {
            return first < second;
        }

        private static bool IsLessThan(Decimal first, Int32 second)
        {
            return first < Convert.ToDecimal(second);
        }

        private static bool IsLessThan(Int32 first, Decimal second)
        {
            return IsLessThan(second, first);
        }

        private static bool IsLessThan(DateTime first, DateTime second)
        {
            return first < second;
        }

        private static bool IsLessThan(TimeSpan first, TimeSpan second)
        {
            return first < second;
        }
    }
}
