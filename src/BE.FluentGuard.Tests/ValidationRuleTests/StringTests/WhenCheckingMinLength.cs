// ==========================================================================
// WhenCheckingMinLength.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.StringTests
{
    public sealed class WhenCheckingMinLength : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenTooSmall()
        {
            ValidationRule<string> sut = GetSut("aaa", "Var");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.MinLength(10));
        }

        [Fact]
        public void ItDoesntThrowsWhenBigEnough()
        {
            ValidationRule<string> sut = GetSut("aaa", "Var");

            sut.MinLength(2);
        }
    }
}