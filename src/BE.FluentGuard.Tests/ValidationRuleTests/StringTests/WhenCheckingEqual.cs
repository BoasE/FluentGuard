// ==========================================================================
// WhenCheckingEqual.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.StringTests
{
    public sealed class WhenCheckingEqual : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenTooSmall()
        {
            var value = "aa";

            ValidationRule<string> sut = GetSut(value, "Var");

            Assert.Throws<ArgumentException>(() => sut.Equal("bb", StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public void ITSuceedsWhenEqual()
        {
            var value = "aa";

            ValidationRule<string> sut = GetSut(value, "Var");

            sut.Equal("aa", StringComparison.OrdinalIgnoreCase);
        }
    }
}