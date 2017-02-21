// ==========================================================================
// ValidationRule.cs
// 
// FlowGuard
// https://github.com/Gentlehag/FlowGuard
// ==========================================================================

using System;

namespace BE.FluentGuard
{
    /// <summary>
    /// Contains the state of the current assertions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ValidationRule<T>
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
        /// The file in which the assertions was triggered.
        /// </summary>
        public string File { get; }

        /// <summary>
        /// The sourcecode which the assertions was triggered.
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// The line of code on which the assertions was triggered.
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// Creates a new validation rules
        /// </summary>
        /// <param name="value">The value on which assertions are made.</param>
        /// <param name="name">Name of the member that contained the value.</param>
        /// <param name="file">The file in which the assertions was triggered.</param>
        /// <param name="source">The sourcecode which the assertions was triggered.</param>
        /// <param name="line">The line of code on which the assertions was triggered.</param>
        public ValidationRule(T value, string name, string file, string source, int line)
        {
            Value = value;
            Name = name;
            File = file;
            Source = source;
            Line = line;
        }

        /// <summary>
        /// Assert that the value is not null
        /// </summary>
        /// <returns>this instance</returns>
        /// <exception cref="ArgumentNullException">If the value is null.</exception>
        public ValidationRule<T> NotNull()
        {
            if (Value == null)
            {
                throw new ArgumentNullException(Name, "Value must not be null!");
            }
            return this;
        }


        /// <summary>
        /// Assert that the value is not equal to the default value of its type
        /// </summary>
        /// <returns>this instance</returns>
        /// <exception cref="ArgumentException">If the value is equal to its type default.</exception>
        public ValidationRule<T> NotDefault()
        {
            var val = default(T);
            if (Value.Equals(val))
            {
                throw new ArgumentException(Name, "Value must have default value!");
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