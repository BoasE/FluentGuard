// ==========================================================================
// WhenCheckingNullOrWhitespace.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ==========================================================================

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.StringTests
{
    public class WhenCheckingNullOrWhitespace : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() => GetSut((string) null, "Var").NotNullOrWhiteSpace());
        }

        [Fact]
        public void ItThrowsWhenEmpty()
        {
            Assert.Throws<ArgumentException>(() => GetSut("", "Var").NotNullOrWhiteSpace());
        }

        [Fact]
        public void ItSucceedsWhenFilled()
        {
            ValidationRule<string> sut = GetSut("asdas", "Var");

            sut.NotNullOrWhiteSpace();
        }

        [Fact]
        public void ItFailsWhenWhitespace()
        {
            Assert.Throws<ArgumentException>(() => GetSut("  ", "Var").NotNullOrWhiteSpace());
        }
    }
}