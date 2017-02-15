// ==========================================================================
// WhenValidatingAModel.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.ModelTests
{
    public sealed class WhenValidatingAModel : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenNull()
        {
            Model a = null;

            Assert.Throws<ArgumentNullException>(() => GetSut(a, "a").ValidModel());
        }

        [Fact]
        public void ItThrowsWhenRequiredIsNotFullfilled()
        {
            Model a = new Model();

            Assert.Throws<ValidationException>(() => GetSut(a, "a").ValidModel());
        }

        [Fact]
        public void SuceedsWhenAnnotationFullfilled()
        {
            Model a = new Model()
            {
                Value = "Aa"
            };

            GetSut(a, "a").ValidModel();
        }
    }
}