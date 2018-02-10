// ==========================================================================
// EnumerableValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using System.Collections;
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
        /// Asserts that the enumerable has items
        /// </summary>
        /// <typeparam name="T">Type of the items in the enumerable</typeparam>
        /// <param name="rule">the validation rule</param>
        /// <exception cref="ArgumentException">If the enumerable has no items</exception>
        /// <returns></returns>
        public static ValidationRule<IEnumerable<T>> Any<T>(this ValidationRule<IEnumerable<T>> rule,Func<T,bool> condition,string message = "The enumerable must have items!")
        {
            if (!rule.Value.HasAny(condition))
            {
                throw new ArgumentException(message, rule.Name);
            }
            return rule;
        }
        
        /// <summary>
        /// Asserts that the enumerable has items
        /// </summary>
        /// <typeparam name="T">Type of the items in the enumerable</typeparam>
        /// <param name="rule">the validation rule</param>
        /// <exception cref="ArgumentException">If the enumerable has no items</exception>
        /// <returns></returns>
        public static ValidationRule<IEnumerable<T>> Any<T>(this ValidationRule<IEnumerable<T>> rule,string message = "The enumerable must have items!")
        {
            if (!rule.Value.HasAny())
            {
                throw new ArgumentException(message, rule.Name);
            }
            return rule;
        }
        
        /// <summary>
        /// Asserts that the collection has items
        /// </summary>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <param name="rule">the validation rule</param>
        /// <exception cref="ArgumentException">If the collection has no items</exception>
        /// <returns></returns>
        public static ValidationRule<ICollection<T>> Any<T>(this ValidationRule<ICollection<T>> rule,Func<T,bool> condition,string message = "The collection must have items!")
        {
            if (!rule.Value.HasAny(condition))
            {
                throw new ArgumentException(message, rule.Name);
            }
            return rule;
        }
        
        /// <summary>
        /// Asserts that the collection has items
        /// </summary>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <param name="rule">the validation rule</param>
        /// <exception cref="ArgumentException">If the collection has no items</exception>
        /// <returns></returns>
        public static ValidationRule<ICollection<T>> Any<T>(this ValidationRule<ICollection<T>> rule,string message = "The collection must have items!")
        {
            if (!rule.Value.HasAny())
            {
                throw new ArgumentException(message, rule.Name);
            }
            return rule;
        }

        public static ValidationRule<ICollection<T>> HasItem<T>(this ValidationRule<ICollection<T>> rule,T item,string message= "The collection must contain the given item!")
        {
            if (!rule.Value.Any(x => x.Equals(item))) 
            {
                throw new ArgumentException(message, rule.Name);
            }
            return rule;
        }

        public static ValidationRule<ICollection<T>> NotNullOrEmpty<T>(this ValidationRule<ICollection<T>> rule)
        {
            if (rule.Value == null)
            {
                throw new ArgumentException("The collection must not be null!",rule.Name);
            }
            if (!rule.Value.HasAny())
            {
                throw new ArgumentException("The enumerable should have items!", rule.Name);
            }
            return rule;
        }

        public static ValidationRule<ICollection> HasAtLeast(this ValidationRule<ICollection> rule,int minimalCount,string message =null)
        {
            if (rule.Value.Count >= minimalCount) return rule;

            if (message == null)
            {
                message = $"The collection must have at least {minimalCount} items.";
            }

            throw new ArgumentOutOfRangeException(rule.Name, rule.Value.Count, message);
        }

        public static ValidationRule<ICollection> HasAtMost(this ValidationRule<ICollection> rule, int maximumCount, string message = null)
        {
            if (rule.Value.Count <= maximumCount) return rule;

            if (message == null)
            {
                message = $"The collection must have at most {maximumCount} items.";
            }

            throw new ArgumentOutOfRangeException(rule.Name, rule.Value.Count, message);
        }

        public static ValidationRule<ICollection> HasExact(this ValidationRule<ICollection> rule, int expectedCount, string message = null)
        {
            if (rule.Value.Count == expectedCount) return rule;

            if (message == null)
            {
                message = $"The collection must have exact {expectedCount} items.";
            }

            throw new ArgumentOutOfRangeException(rule.Name, rule.Value.Count, message);
        }
        private static bool HasAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }
        
        private static bool HasAny<T>(this IEnumerable<T> data,Func<T,bool> predicate)
        {
            return data != null && data.Any(predicate);
        }
    }
}