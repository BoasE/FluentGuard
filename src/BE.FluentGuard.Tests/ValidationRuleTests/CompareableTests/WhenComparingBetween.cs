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
    public  class WhenComparingBetween : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenValueIsToSmall()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(1, "a").Between(2,3));
        }

        [Fact]
        public void ItThrowsWhenValueIsToBig()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(4, "a").Between(2, 3));
        }

        [Fact]
        public void ItThrowsWhenItIsUpperBound()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(4, "a").Between(2, 4));
        }

        [Fact]
        public void ItThrowsWhenItIsLowerBound()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(2, "a").Between(2, 4));
        }

        [Fact]
        public void ItSucceedsWheBetween()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.Between(2, 4);
        }
    }
}