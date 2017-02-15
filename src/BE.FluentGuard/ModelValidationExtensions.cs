// ==========================================================================
// ModelValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System.ComponentModel.DataAnnotations;

namespace BE.FluentGuard
{
    public static class ModelValidationExtensions
    {
        public static ValidationRule<T> ValidModel<T>(this ValidationRule<T> rule) where T : class
        {
            var context = new ValidationContext(rule.Value);
            Validator.ValidateObject(rule.Value, context);

            return rule;
        }
    }
}