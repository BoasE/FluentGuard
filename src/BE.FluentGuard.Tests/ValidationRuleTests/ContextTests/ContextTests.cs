// ==========================================================================
// ContextTests.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.ContextTests
{
    public abstract class ContextTests<T>
    {
        protected abstract T ExpectedValue { get; }

        protected abstract string ExpectedMemberName { get; }

        protected abstract ValidationRule<T> GetSut();

        [Fact]
        public void ItHasTheMemberName()
        {
            ValidationRule<T> rule = GetSut();
            Assert.Equal(ExpectedMemberName, rule.Name);
        }

        [Fact]
        public void ItHasTheValue()
        {
            ValidationRule<T> rule = GetSut();
            Assert.Equal(ExpectedValue, rule.Value);
        }

        [Fact]
        public void ItHasLineAndSource()
        {
            ValidationRule<T> rule = GetSut();

            Assert.False(string.IsNullOrWhiteSpace(rule.Source));
            Assert.True(rule.Line > 10);
        }

        [Fact]
        public void ItHasFileNames()
        {
            ValidationRule<T> rule = GetSut();

            Assert.False(string.IsNullOrWhiteSpace(rule.File));
        }
    }
}