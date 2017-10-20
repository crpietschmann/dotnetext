//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

namespace dotNetExt
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using dotNetExt.Validation;

    public static class ValidationArgumentExtensions
    {
        public static ValidationArgument<T> RequireArgument<T>(this T arg, string name)
        {
            return new ValidationArgument<T>(name, arg);
        }

        #region "NotNull"
        
        [DebuggerHidden]
        public static ValidationArgument<T> NotNull<T>(this ValidationArgument<T> arg)
        {
            if (arg.Value.IsNull())
            {
                throw new ArgumentNullException(arg.Name);
            }
            return arg;
        }

        #endregion

        #region "NotEmpty"

        [DebuggerHidden]
        public static ValidationArgument<T> NotEmpty<T>(this ValidationArgument<T> arg) where T : System.Collections.IEnumerable
        {
            arg.NotNull();
            if (arg.Value.IsEmpty())
            {
                throw new ArgumentOutOfRangeException(arg.Name);
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<IEnumerable<T>> NotEmpty<T>(this ValidationArgument<IEnumerable<T>> arg)
        {
            if (arg.Value.IsEmpty())
            {
                throw new ArgumentOutOfRangeException(arg.Name);
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<string> NotEmpty(this ValidationArgument<string> arg)
        {
            if (arg.Value.Length == 0)
            {
                throw new ArgumentOutOfRangeException(arg.Name);
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<Guid> NotEmpty(this ValidationArgument<Guid> arg)
        {
            if (arg.Value == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException(arg.Name, "Guid can not be equal to Guid.Empty");
            }
            return arg;
        }

        #endregion

        #region "NotNullOrWhiteSpace"

        [DebuggerHidden]
        public static ValidationArgument<string> NotNullOrWhiteSpace(this ValidationArgument<string> arg)
        {
            if (arg.Value.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("String can not be Null or WhiteSpace", arg.Name);
            }
            return arg;
        }

        #endregion

        #region "InRange"

        [DebuggerHidden]
        public static ValidationArgument<int> InRange(this ValidationArgument<int> arg, int minValue, int maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<int?> InRange(this ValidationArgument<int?> arg, int minValue, int maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<double> InRange(this ValidationArgument<double> arg, double minValue, double maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<double?> InRange(this ValidationArgument<double?> arg, double minValue, double maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<short> InRange(this ValidationArgument<short> arg, short minValue, short maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<short?> InRange(this ValidationArgument<short?> arg, short minValue, short maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<long> InRange(this ValidationArgument<long> arg, long minValue, long maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<long?> InRange(this ValidationArgument<long?> arg, long minValue, long maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<float> InRange(this ValidationArgument<float> arg, float minValue, float maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<float?> InRange(this ValidationArgument<float?> arg, short minValue, float maxValue)
        {
            if (arg.Value < minValue || arg.Value > maxValue)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<T> InRange<T>(this ValidationArgument<T> arg, T minValue, T maxValue) where T: IComparable
        {
            if (arg.Value.CompareTo(minValue) < 0 || arg.Value.CompareTo(maxValue) > 0)
            {
                throwOutOfRange(arg.Name, minValue.ToString(), maxValue.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        private static void throwOutOfRange(string paramName, string min, string max)
        {
            throw new ArgumentOutOfRangeException(paramName, string.Format("Out of Range (min: {0}) (max: {1})", min, max));
        }

        #endregion

        #region StartsWith

        [DebuggerHidden]
        public static ValidationArgument<string> StartsWith(this ValidationArgument<string> arg, string value)
        {
            if (!arg.Value.StartsWith(value))
            {
                throwStartsWith(arg.Name, value);
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<string> StartsWith(this ValidationArgument<string> arg, string value, StringComparison stringComparison)
        {
            if (!arg.Value.StartsWith(value, stringComparison))
            {
                throwStartsWith(arg.Name, value);
            }
            return arg;
        }

        [DebuggerHidden]
        private static void throwStartsWith(string paramName, string val)
        {
            throw new ArgumentException(string.Format("Parameter ({0}) must start with '{1}'", paramName, val), paramName);
        }

        #endregion

        #region EndsWith

        [DebuggerHidden]
        public static ValidationArgument<string> EndsWith(this ValidationArgument<string> arg, string value)
        {
            if (!arg.Value.EndsWith(value))
            {
                throwEndsWith(arg.Name, value);
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<string> EndsWith(this ValidationArgument<string> arg, string value, StringComparison stringComparison)
        {
            if (!arg.Value.EndsWith(value, stringComparison))
            {
                throwEndsWith(arg.Name, value);
            }
            return arg;
        }

        [DebuggerHidden]
        private static void throwEndsWith(string paramName, string val)
        {
            throw new ArgumentException(string.Format("Parameter ({0}) must end with '{1}'", paramName, val), paramName);
        }

        #endregion

        #region Contains

        [DebuggerHidden]
        public static ValidationArgument<string> Contains(this ValidationArgument<string> arg, string value)
        {
            if (!arg.Value.Contains(value))
            {
                throwContains(arg.Name, value);
            }
            return arg;
        }

        [DebuggerHidden]
        private static void throwContains(string paramName, string val)
        {
            throw new ArgumentException(string.Format("Parameter ({0}) must contain '{1}'", paramName, val), paramName);
        }

        #endregion

        #region LessThan

        [DebuggerHidden]
        public static ValidationArgument<int> LessThan(this ValidationArgument<int> arg, int value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<int?> LessThan(this ValidationArgument<int?> arg, int value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<short> LessThan(this ValidationArgument<short> arg, short value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<short?> LessThan(this ValidationArgument<short?> arg, short value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<long> LessThan(this ValidationArgument<long> arg, long value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<long?> LessThan(this ValidationArgument<long?> arg, long value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;

        }
        [DebuggerHidden]
        public static ValidationArgument<double> LessThan(this ValidationArgument<double> arg, double value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<double?> LessThan(this ValidationArgument<double?> arg, double value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<float> LessThan(this ValidationArgument<float> arg, float value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<float?> LessThan(this ValidationArgument<float?> arg, float value)
        {
            if (arg.Value >= value)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<T> LessThan<T>(this ValidationArgument<T> arg, T value) where T: IComparable
        {
            if (arg.Value.CompareTo(value) >= 0)
            {
                throwLessThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        private static void throwLessThan(string paramName, string actualValue, string expectedValue)
        {
            throw new ArgumentOutOfRangeException(paramName, string.Format("Value ({2}) of parameter ({0}) must be less than '{1}'", paramName, expectedValue, actualValue));
        }

        #endregion

        #region GreaterThan

        [DebuggerHidden]
        public static ValidationArgument<int> GreaterThan(this ValidationArgument<int> arg, int value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<int?> GreaterThan(this ValidationArgument<int?> arg, int value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<short> GreaterThan(this ValidationArgument<short> arg, short value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<short?> GreaterThan(this ValidationArgument<short?> arg, short value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<long> GreaterThan(this ValidationArgument<long> arg, long value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<long?> GreaterThan(this ValidationArgument<long?> arg, long value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;

        }
        [DebuggerHidden]
        public static ValidationArgument<double> GreaterThan(this ValidationArgument<double> arg, double value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<double?> GreaterThan(this ValidationArgument<double?> arg, double value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<float> GreaterThan(this ValidationArgument<float> arg, float value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<float?> GreaterThan(this ValidationArgument<float?> arg, float value)
        {
            if (arg.Value <= value)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        public static ValidationArgument<T> GreaterThan<T>(this ValidationArgument<T> arg, T value) where T : IComparable
        {
            if (arg.Value.CompareTo(value) <= 0)
            {
                throwGreaterThan(arg.Name, arg.Value.ToString(), value.ToString());
            }
            return arg;
        }

        [DebuggerHidden]
        private static void throwGreaterThan(string paramName, string actualValue, string expectedValue)
        {
            throw new ArgumentOutOfRangeException(paramName, string.Format("Value ({2}) of parameter ({0}) must be greater than '{1}'", paramName, expectedValue, actualValue));
        }

        #endregion

        #region ShorterThan

        [DebuggerHidden]
        public static ValidationArgument<string> ShorterThan(this ValidationArgument<string> arg, int value)
        {
            if (arg.Value.Length >= value)
            {
                throw new ArgumentException(string.Format("Length ({2}) of Parameter ({0}) must be less than {1}", arg.Name, value.ToString(), arg.Value.Length), arg.Name);
            }
            return arg;
        }

        #endregion

        #region LongerThan

        [DebuggerHidden]
        public static ValidationArgument<string> LongerThan(this ValidationArgument<string> arg, int value)
        {
            if (arg.Value.Length <= value)
            {
                throw new ArgumentException(string.Format("Length ({2}) of Parameter ({0}) must be greater than {1}", arg.Name, value.ToString(), arg.Value.Length), arg.Name);
            }
            return arg;
        }

        #endregion

        #region IsMatch

        /// <summary>
        /// Validates that the String matches the specified regular expression.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="regularExpressionToMatch">The regular expression pattern to match.</param>
        /// <returns></returns>
        [DebuggerHidden]
        public static ValidationArgument<string> IsMatch(this ValidationArgument<string> arg, string regularExpressionToMatch)
        {
            if (!Regex.IsMatch(arg.Value, regularExpressionToMatch))
            {
                throwIsMatch(arg.Name, arg.Value, regularExpressionToMatch);
            }
            return arg;
        }

        /// <summary>
        /// Validates that the String matches the specified regular expression.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="regularExpressionToMatch">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <returns></returns>
        [DebuggerHidden]
        public static ValidationArgument<string> IsMatch(this ValidationArgument<string> arg, string regularExpressionToMatch, RegexOptions options)
        {
            if (!Regex.IsMatch(arg.Value, regularExpressionToMatch, options))
            {
                throwIsMatch(arg.Name, arg.Value, regularExpressionToMatch);
            }
            return arg;
        }

        private static void throwIsMatch(string paramName, string val, string regex)
        {
            throw new ArgumentException(string.Format("Parameter ({0}) Value ({1}) does not match regular expression: {2}", paramName, val, regex), paramName);
        }

        #endregion
    }
}
