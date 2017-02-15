// ==========================================================================
// EnumerableValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using System.Collections.Generic;
using System.Linq;

namespace BE.FluentGuard
{
    /// <summary>
    /// Offers methods for asserting Enumerable objects
    /// </summary>
    public static class EnumerableValidationExtensions
    {
        /// <summary>
        /// Asserts that the collection has items
        /// </summary>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <param name="rule">the validation rule</param>
        /// <exception cref="ArgumentException">If the collection has no items</exception>
        /// <returns></returns>
        public static ValidationRule<ICollection<T>> HasItems<T>(this ValidationRule<ICollection<T>> rule)
        {
            if (!rule.Value.HasAny())
            {
                throw new ArgumentException("The enumerable should have items!");
            }
            return rule;
        }

        private static bool HasAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
    }
}