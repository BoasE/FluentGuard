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

            ValidationRule<ICollection<string>> sut = GetSut(val, "a");

            Assert.Throws<ArgumentException>(() => sut.Any());
        }

        [Fact]
        public void SuccedesWhenItHasItems()
        {
            ICollection<string> val = new List<string>
            {
                "a"
            };

            ValidationRule<ICollection<string>> sut = GetSut(val, "a");

            sut.Any();
        }

        [Fact]
        public void FailsWhenListIsEmptry()
        {
            ICollection<string> val = new List<string>();

            ValidationRule<ICollection<string>> sut = GetSut(val, "a");

            Assert.Throws<ArgumentException>(() => sut.Any());
        }
    }
}