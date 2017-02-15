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
            ValidationRule<string> sut = GetSut((string)null, "Var");

            Assert.Throws<ArgumentNullException>(() => sut.NotNullOrWhiteSpace());
        }

        [Fact]
        public void ItThrowsWhenEmpty()
        {
            ValidationRule<string> sut = GetSut("", "Var");

            Assert.Throws<ArgumentException>(() => sut.NotNullOrWhiteSpace());
        }

        [Fact]
        public void ItSuceedsWhenfilled()
        {
            ValidationRule<string> sut = GetSut("asdas", "Var");

            sut.NotNullOrWhiteSpace();
        }

        [Fact]
        public void ItFailsWhenWhitespace()
        {
            ValidationRule<string> sut = GetSut("  ", "Var");

            Assert.Throws<ArgumentException>(() => sut.NotNullOrWhiteSpace());
        }
    }
}