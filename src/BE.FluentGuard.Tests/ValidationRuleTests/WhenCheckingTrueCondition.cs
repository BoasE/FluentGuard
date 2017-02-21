// ==========================================================================
// WhenCheckingTrueCondition.cs
// 
// FlowGuard
// https://github.com/Gentlehag/FlowGuard
// ==========================================================================

using System;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests
{
    public class WhenCheckingTrueCondition : GivenValidationRule
    {
        [Fact]
        public void ItThrowsIfFalse()
        {
            var sut = GetSut("a", "para");

            Assert.Throws<ArgumentException>(() => sut.True(val => val.Equals("b")));
        }

        [Fact]
        public void SuceedsWhenTrue()
        {
            var sut = GetSut("a", "para");

            sut.True(val => val.Equals("a"));
        }
    }
}