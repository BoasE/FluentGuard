// ==========================================================================
// WhenCheckingNull.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests
{
    public class WhenCheckingNull : GivenValidationRule
    {
        [Fact]
        public void ItThrows()
        {
            ValidationRule<string> sut = GetSut((string)null, "myVar");

            Assert.Throws<ArgumentNullException>(() => sut.NotNull());
        }

        [Fact]
        public void ItDoesntThrowsIfNotNull()
        {
            ValidationRule<string> sut = GetSut("aa", "myVar");

            sut.NotNull();
        }
    }
}