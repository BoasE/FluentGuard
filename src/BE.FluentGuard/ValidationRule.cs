// ==========================================================================
// ValidationRule.cs
//
// FlowGuard
// https://github.com/Gentlehag/FlowGuard
// ==========================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BE.FluentGuard
{
    /// <summary>
    /// Contains the state of the current assertions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public ref readonly struct ValidationRule<T>
    {
        /// <summary>
        /// The value on which assertions are made.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Name of the member that contained the value.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Creates a new validation rules
        /// </summary>
        /// <param name="value">The value on which assertions are made.</param>
        /// <param name="name">Name of the member that contained the value.</param>
        public ValidationRule(T value, string name)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Assert that the value is not null
        /// </summary>
        /// <returns>this instance</returns>
        /// <exception cref="ArgumentNullException">If the value is null.</exception>
        public ValidationRule<T> NotNull(string message = "Value must not be null!")
        {
            if (Value == null)
            {
                throw new ArgumentNullException(Name, message);
            }

            return this;
        }

        /// <summary>
        /// Validates if the annotated rules are fullfilled
        /// </summary>
        /// <returns></returns>
        public ValidationRule<T> IsValidModel()
        {
            Validator.ValidateObject(Value, new ValidationContext(Value));
            return this;
        }

        /// <summary>
        /// Assert that the value is not equal to the default value of its type
        /// </summary>
        /// <returns>this instance</returns>
        /// <exception cref="ArgumentException">If the value is equal to its type default.</exception>
        public ValidationRule<T> NotDefault(string message = "Value must have default value!")
        {
            if (EqualityComparer<T>.Default.Equals(Value, default))
            {
                throw new ArgumentException(Name, message);
            }

            return this;
        }

        public ValidationRule<T> False(Predicate<T> condition, string message = null)
        {
            if (!condition(Value)) return this;

            if (message == null)
            {
                message = $"Condition for {Name} was not met.";
            }

            throw new ArgumentException(message, Name);
        }

        public ValidationRule<T> True(Predicate<T> condition, string message = null)
        {
            if (condition(Value)) return this;

            if (message == null)
            {
                message = $"Condition for {Name} was not met.";
            }

            throw new ArgumentException(message, Name);
        }
    }
}