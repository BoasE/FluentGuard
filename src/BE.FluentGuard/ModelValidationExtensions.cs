// ==========================================================================
// ModelValidationExtensions.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System.ComponentModel.DataAnnotations;

namespace BE.FluentGuard
{
    /// <summary>
    /// Contains methods for validation models annotated with Attribute from <c>System.ComponentModel.Annotations</c>
    /// </summary>
    public static class ModelValidationExtensions
    {

        /// <summary>
        /// Validates wether the given model fulfills all of this annotated definitions
        /// </summary>
        /// <typeparam name="T">Type of the model that should be validated</typeparam>
        /// <param name="rule">The rule on which it should be validated</param>
        /// <returns>A ValidationRule on which assertions can be made.</returns>
        /// <exception cref="ValidationException">If the model doesn't fullfill its annotations</exception>
        public static ValidationRule<T> ValidModel<T>(this ValidationRule<T> rule) where T : class
        {
            var context = new ValidationContext(rule.Value);
            Validator.ValidateObject(rule.Value, context);

            return rule;
        }
    }
}