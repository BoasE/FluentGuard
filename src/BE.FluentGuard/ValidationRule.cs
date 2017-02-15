// ==========================================================================
// ValidationRule.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;

namespace BE.FluentGuard
{
    public sealed class ValidationRule<T>
    {
        public T Value { get; }

        public string Name { get; }

        public string File { get; }

        public string Source { get; }

        public int Line { get; }

        public ValidationRule(T value, string name, string file, string source, int line)
        {
            Value = value;
            Name = name;
            File = file;
            Source = source;
            Line = line;
        }

        public ValidationRule<T> NotNull()
        {
            if (Value == null)
            {
                throw new ArgumentNullException(Name, "Value must not be null!");
            }
            return this;
        }

        public ValidationRule<T> NotDefault()
        {
            T val = default(T);
            if (Value.Equals(val))
            {
                throw new ArgumentException(Name, "Value must have default value!");
            }
            return this;
        }
    }
}