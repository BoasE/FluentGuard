// ==========================================================================
// CompareableValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;

namespace BE.FluentGuard
{
    public static class CompareableValidationExtensions
    {
        public static ValidationRule<T> AtLeast<T>(this ValidationRule<T> rule, T minimal) where T : IComparable
        {
            if (rule.Value.CompareTo(minimal) < 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be at least \"{minimal}\" !");
            }
            return rule;
        }

        public static ValidationRule<T> AtMost<T>(this ValidationRule<T> rule, T maximum) where T : IComparable
        {
            if (rule.Value.CompareTo(maximum) > 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be at least \"{maximum}\" !");
            }
            return rule;
        }

        public static ValidationRule<T> Between<T>(this ValidationRule<T> rule, T minimal, T maximum) where T : IComparable
        {
            if (rule.Value.CompareTo(maximum) >= 0 || rule.Value.CompareTo(minimal) <= 0)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value, $"The value should be between \"{minimal}\" and \"{maximum}\" !");
            }
            return rule;
        }

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