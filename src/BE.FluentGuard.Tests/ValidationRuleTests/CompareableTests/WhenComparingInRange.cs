﻿// ==========================================================================
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
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(1, "a").InRange(2, 3));
        }

        [Fact]
        public void ItThrowsWhenValueIsToBig()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GetSut(4, "a").InRange(2, 3));
        }

        [Fact]
        public void ItSucceedsWhenItIsUpperBound()
        {
            ValidationRule<int> sut = GetSut(4, "a");

            sut.InRange(2, 4);
        }

        [Fact]
        public void ItSucceedsWhenItIsLowerBound()
        {
            ValidationRule<int> sut = GetSut(2, "a");

            sut.InRange(2, 4);
        }

        [Fact]
        public void ItSucceedsWheBetween()
        {
            ValidationRule<int> sut = GetSut(3, "a");

            sut.Between(2, 4);
        }
    }
}