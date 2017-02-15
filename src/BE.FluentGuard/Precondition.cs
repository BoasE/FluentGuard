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
    public static class Precondition
    {
        public static ValidationRule<T> For<T>(T value, string name, [CallerFilePath] string file = null,
            [CallerMemberName] string source = null, [CallerLineNumber] int line = -1)
        {
            return new ValidationRule<T>(value, name, file, source, line);
        }

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