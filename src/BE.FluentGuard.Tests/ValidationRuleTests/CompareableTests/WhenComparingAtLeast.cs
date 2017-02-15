// ==========================================================================
// WhenComparingAtLeast.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.CompareableTests
{
    public class WhenComparingAtLeast : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenValueIsTosmall()
        {
            ValidationRule<int> sut = GetSut(1, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.AtLeast(2));
        }

        [Fact]
        public void SuceedsWhenBigger()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtLeast(2);
        }

        [Fact]
        public void SuceedsWhenEqual()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtLeast(3);
        }
    }
}