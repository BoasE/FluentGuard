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
            ValidationRule<string> sut = GetSut((string)null, "Var");

            Assert.Throws<ArgumentNullException>(() => sut.NotNullOrEmpty());
        }

        [Fact]
        public void ItThrowsWhenEmpty()
        {
            ValidationRule<string> sut = GetSut("", "Var");

            Assert.Throws<ArgumentException>(() => sut.NotNullOrEmpty());
        }

        [Fact]
        public void ItSuceedsWhenfilled()
        {
            ValidationRule<string> sut = GetSut("asdas", "Var");

            sut.NotNullOrEmpty();
        }

        [Fact]
        public void ItSuceedsWhenWhitespace()
        {
            ValidationRule<string> sut = GetSut("  ", "Var");

            sut.NotNullOrEmpty();
        }
    }
}