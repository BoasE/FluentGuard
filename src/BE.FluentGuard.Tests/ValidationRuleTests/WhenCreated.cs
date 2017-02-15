// ==========================================================================
// WhenCreated.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests
{
    public class WhenCreated : GivenValidationRule
    {
        [Fact]
        public void ItsNotNull()
        {
            ValidationRule<string> sut = GetSut("Test", "myVar");

            Assert.NotNull(sut);
        }

        [Fact]
        public void ItsNotNullWhenValueIsNull()
        {
            ValidationRule<string> sut = GetSut((string)null, "myVar");

            Assert.NotNull(sut);
        }
    }
}