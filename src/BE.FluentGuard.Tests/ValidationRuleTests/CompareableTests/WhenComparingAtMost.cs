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
            ValidationRule<int> sut = GetSut(4, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.AtMost(2));
        }

        [Fact]
        public void SuceedsWhenSmaller()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtMost(4);
        }

        [Fact]
        public void SuceedsWhenEqual()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.AtMost(3);
        }
    }
}