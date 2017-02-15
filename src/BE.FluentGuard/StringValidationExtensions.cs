// ==========================================================================
// StringValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;

namespace BE.FluentGuard
{
    public static class StringValidationExtensions
    {
        public static ValidationRule<string> MinLength(this ValidationRule<string> rule, int length)
        {
            if (string.IsNullOrWhiteSpace(rule.Value) || rule.Value.Length < length)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value.Length, $"The value should be at least {length} characters long!");
            }
            return rule;
        }

        public static ValidationRule<string> Equal(this ValidationRule<string> rule, string value,
            StringComparison comparison)
        {
            if (!string.Equals(rule.Value, value, comparison))
            {
                throw new ArgumentException(rule.Name, "Value must not be null or empty!");
            }
            return rule;
        }

        public static ValidationRule<string> NotNullOrEmpty(this ValidationRule<string> rule)
        {
            if (rule.Value == null)
            {
                throw new ArgumentNullException(rule.Name, "Value must not be null!");
            }

            if (string.IsNullOrEmpty(rule.Value))
            {
                throw new ArgumentException(rule.Name, "Value must not be null or empty!");
            }
           
            return rule;
        }

        public static ValidationRule<string> NotNullOrWhiteSpace(this ValidationRule<string> rule)
        {
            if (rule.Value == null)
            {
                throw new ArgumentNullException(rule.Name, "Value must not be null!");
            }

            if (string.IsNullOrWhiteSpace(rule.Value))
            {
                throw new ArgumentException(rule.Name, "Value must not be null or empty!");
            }

            return rule;
        }
    }
}