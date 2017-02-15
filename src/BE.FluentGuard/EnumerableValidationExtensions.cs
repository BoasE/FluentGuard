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
    public static class EnumerableValidationExtensions
    {
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