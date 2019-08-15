// ==========================================================================
// WhenCheckingNullOrEmpty.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ==========================================================================

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.StringTests
{
    public class WhenCheckingNullOrEmpty : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => GetSut((string)null, "Var").NotNullOrEmpty());
        }

        [Fact]
        public void ItThrowsWhenEmpty()
        {
            Assert.Throws<ArgumentException>(() => GetSut("", "Var").NotNullOrEmpty());
        }

        [Fact]
        public void ItSucceedsWhenFilled()
        {
            ValidationRule<string> sut = GetSut("asdas", "Var");

            sut.NotNullOrEmpty();
        }

        [Fact]
        public void ItSucceedsWhenWhitespace()
        {
            ValidationRule<string> sut = GetSut("  ", "Var");

            sut.NotNullOrEmpty();
        }
    }
}