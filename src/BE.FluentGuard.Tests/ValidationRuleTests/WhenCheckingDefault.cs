// ==========================================================================
// WhenCheckingDefault.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ==========================================================================

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests
{
    public sealed class WhenCheckingDefault : GivenValidationRule
    {
        [Fact]
        public void ItThrowsIfDefault()
        {
            Assert.Throws<ArgumentException>(() => GetSut(default(int), "myVar").NotDefault());
        }

        [Fact]
        public void DoesntThrowIfNotDefault()
        {
            var sut = GetSut(14, "myVar");

            sut.NotDefault();
        }
    }
}