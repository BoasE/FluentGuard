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
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(1, "a").AtLeast(2));
        }

        [Fact]
        public void SucceedsWhenBigger()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtLeast(2);
        }

        [Fact]
        public void SucceedsWhenEqual()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtLeast(3);
        }
    }
}