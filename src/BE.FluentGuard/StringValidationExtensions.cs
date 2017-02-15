// ==========================================================================
// StringValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;

namespace BE.FluentGuard
{
    /// <summary>
    /// Contains methods for asserting string values
    /// </summary>
    public static class StringValidationExtensions
    {
        /// <summary>
        /// Asserts that the given string is at least as long as the given length.
        /// </summary>
        /// <param name="rule">rule on which it should be asserted.</param>
        /// <param name="length">minimal length of the string.</param>
        /// <returns>The validation rule.</returns>
        public static ValidationRule<string> MinLength(this ValidationRule<string> rule, int length)
        {
            if (string.IsNullOrWhiteSpace(rule.Value) || rule.Value.Length < length)
            {
                throw new ArgumentOutOfRangeException(rule.Name, rule.Value.Length, $"The value should be at least {length} characters long!");
            }
            return rule;
        }

        /// <summary>
        /// Checks that the given string is equal to the passed string.
        /// </summary>
        /// <param name="rule">rule on which it should be asserted.</param>
        /// <param name="value">The value the asserted value should have</param>
        /// <param name="comparison">The comparison behavior</param>
        /// <returns>The validation rule.</returns>
        /// /// <exception cref="ArgumentException">If the asserted string isn't equal to the given strign</exception>
        public static ValidationRule<string> Equal(this ValidationRule<string> rule, string value,
            StringComparison comparison)
        {
            if (!string.Equals(rule.Value, value, comparison))
            {
                throw new ArgumentException(rule.Name, "Value must not be null or empty!");
            }
            return rule;
        }

        /// <summary>
        /// Checks that the given string is not null or empty
        /// </summary>
        /// <param name="rule">rule on which it should be asserted.</param>
        /// <returns>The validation rule.</returns>
        /// <exception cref="ArgumentNullException">If the asserted string is null</exception>
        /// <exception cref="ArgumentException">If the asserted string is empty</exception>
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

        /// <summary>
        /// Checks that the given string is not null or whitespace
        /// </summary>
        /// <param name="rule">rule on which it should be asserted.</param>
        /// <returns>The validation rule.</returns>
        /// <exception cref="ArgumentNullException">If the asserted string is null</exception>
        /// <exception cref="ArgumentException">If the asserted string is empty or whitespaces only</exception>
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