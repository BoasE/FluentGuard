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
            Assert.Throws<ArgumentNullException>(() => GetSut((string)null, "myVar").NotNull());
        }

        [Fact]
        public void ItDoesntThrowsIfNotNull()
        {
            ValidationRule<string> sut = GetSut("aa", "myVar");

            sut.NotNull();
        }
    }
}