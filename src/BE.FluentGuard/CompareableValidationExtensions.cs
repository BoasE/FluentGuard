// ==========================================================================
// CompareableValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ==========================================================================

using System;

namespace BE.FluentGuard
{
    /// <summary>
    /// Offers Asserts on Compareable objects
    /// </summary>
    public static class CompareableValidationExtensions
    {
        /// <summary>
        /// Asserts that the value is at least the value that is passed
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="rule">ValidationRule instance</param>
        /// <param name="minimal">The minimal value</param>
        ///<exception cref="ArgumentOutOfRangeException">When the value is below the minimal</exception>
        /// <returns></returns>
        public static ValidationRule<T> AtLeast<T>(this ValidationRule<T> rule, T minimal) where T : IComparable
        {
            if (rule.Value.CompareTo(minimal) < 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be at least \"{minimal}\" !");
            }

            return rule;
        }

        /// <summary>
        /// Asserts that the value is at most the value that is passed
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="rule">ValidationRule instance</param>
        /// <param name="maximum">The maximal value</param>
        ///<exception cref="ArgumentOutOfRangeException">When the value is above the maximum</exception>
        /// <returns></returns>
        public static ValidationRule<T> AtMost<T>(this ValidationRule<T> rule, T maximum) where T : IComparable
        {
            if (rule.Value.CompareTo(maximum) > 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be at least \"{maximum}\" !");
            }

            return rule;
        }

        /// <summary>
        /// Asserts that the value is between
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="rule">ValidationRule instance</param>
        /// <param name="maximum">The maximal value</param>
        ///<param name="minimal">The minimal value</param>
        ///<exception cref="ArgumentOutOfRangeException">When the value is not between maximum and minimum</exception>
        /// <returns></returns>
        public static ValidationRule<T> Between<T>(this ValidationRule<T> rule, T minimal, T maximum) where T : IComparable
        {
            if (rule.Value.CompareTo(maximum) >= 0 || rule.Value.CompareTo(minimal) <= 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be between \"{minimal}\" and \"{maximum}\" !");
            }

            return rule;
        }

        /// <summary>
        /// Asserts that the value is in the range of the minimum and maximum
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="rule">ValidationRule instance</param>
        /// <param name="maximum">The biggest allowed value</param>
        ///<param name="minimal">The lowest allowed</param>
        ///<exception cref="ArgumentOutOfRangeException">When the value islower minimum or bigger maximum</exception>
        /// <returns></returns>
        public static ValidationRule<T> InRange<T>(this ValidationRule<T> rule, T minimal, T maximum) where T : IComparable
        {
            if (rule.Value.CompareTo(maximum) > 0 || rule.Value.CompareTo(minimal) < 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be between \"{minimal}\" and \"{maximum}\" !");
            }

            return rule;
        }
    }
}