// ==========================================================================
// Precondition.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace BE.FluentGuard
{
    /// <summary>
    /// Precondition create the Validation rule for asserting. The starting point for assertions.
    /// </summary>
    public static class Precondition
    {
        /// <summary>
        /// Creates a new precondition for the given argument value.
        /// </summary>
        /// <typeparam name="T">Type of the argument value.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="name">The name of the argument, used for exception messages.</param>
        /// <param name="file">The file in which the argument was used.</param>
        /// <param name="source">Source in which the argument was used.</param>
        /// <param name="line">the line in the file in which the precondition was checked.</param>
        /// <returns>A ValidationRule on which assertions can be made.</returns>
        public static ValidationRule<T> For<T>(T value, string name, [CallerFilePath] string file = null,
            [CallerMemberName] string source = null, [CallerLineNumber] int line = -1)
        {
            return new ValidationRule<T>(value, name, file, source, line);
        }

        /// <summary>
        /// Creates a new precondition for the given argument value.
        /// </summary>
        /// <param name="memberExpression">Expression for the member whose value should be checked</param>
        /// <typeparam name="T">Type of the argument value.</typeparam>
        /// <param name="file">The file in which the argument was used.</param>
        /// <param name="source">Source in which the argument was used.</param>
        /// <param name="line">the line in the file in which the precondition was checked.</param>
        /// <returns>A ValidationRule on which assertions can be made.</returns>
        public static ValidationRule<T> For<T>(Expression<Func<T>> memberExpression, [CallerFilePath] string file = null,
            [CallerMemberName] string source = null, [CallerLineNumber] int line = -1)
        {
            string name = GetMemberName(memberExpression);
            T val = memberExpression.Compile()();
            return new ValidationRule<T>(val, name, file, source, line);
        }

        private static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            var expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }
}