// ==========================================================================
// WhenCheckingHasItems.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ==========================================================================

using System;
using System.Collections.Generic;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.EnumerableTests
{
    public sealed class WhenCheckingHasItems : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenNullCollection()
        {
            ICollection<string> val = null;

            Assert.Throws<ArgumentException>(() => GetSut(val, "a").Any());
        }

        [Fact]
        public void SucceedsWhenItHasItems()
        {
            ICollection<string> val = new List<string>
            {
                "a"
            };

            ValidationRule<ICollection<string>> sut = GetSut(val, "a");

            sut.Any();
        }

        [Fact]
        public void FailsWhenListIsEmpty()
        {
            ICollection<string> val = new List<string>();

            Assert.Throws<ArgumentException>(() => GetSut(val, "a").Any());
        }
    }
}