// ==========================================================================
// WhenComparingInRange.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.CompareableTests
{
    public class WhenComparingInRange : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenValueIsToSmall()
        {
            ValidationRule<int> sut = GetSut(1, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.InRange(2, 3));
        }

        [Fact]
        public void ItThrowsWhenValueIsToBig()
        {
            ValidationRule<int> sut = GetSut(4, "a");

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.InRange(2, 3));
        }

        [Fact]
        public void ItSucceedsWhenItIsUpperBound()
        {
            ValidationRule<int> sut = GetSut(4, "a");

            sut.InRange(2, 4);
        }

        [Fact]
        public void ItSuceedsWhenItIsLowerBound()
        {
            ValidationRule<int> sut = GetSut(2, "a");

            sut.InRange(2, 4);
        }

        [Fact]
        public void ItSuceedsWheBetween()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.Between(2, 4);
        }
    }
}