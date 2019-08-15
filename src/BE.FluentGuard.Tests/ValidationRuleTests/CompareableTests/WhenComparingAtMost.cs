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
    public class WhenComparingAtMost : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenValueIsToBig()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(4, "a").AtMost(2));
        }

        [Fact]
        public void SucceedsWhenSmaller()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtMost(4);
        }

        [Fact]
        public void SucceedsWhenEqual()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtMost(3);
        }
    }
}