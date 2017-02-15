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
            ValidationRule<int> sut = GetSut(1, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Between(2,3));
        }

        [Fact]
        public void ItThrowsWhenValueIsToBig()
        {
            ValidationRule<int> sut = GetSut(4, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Between(2, 3));
        }

        [Fact]
        public void ItThrowsWhenItIsUpperBound()
        {
            ValidationRule<int> sut = GetSut(4, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Between(2, 4));
        }

        [Fact]
        public void ItThrowsWhenItIsLowerBound()
        {
            ValidationRule<int> sut = GetSut(2, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Between(2, 4));
        }

        [Fact]
        public void ItSuceedsWheBetween()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.Between(2, 4);
        }
    }
}