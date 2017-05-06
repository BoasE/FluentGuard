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
    public class WhenCheckingFalseCondition : GivenValidationRule
    {
        [Fact]
        public void ItThrowsIfTrue()
        {
            var sut = GetSut("a", "para");

            Assert.Throws<ArgumentException>(() => sut.False(val => val.Equals("a")));
        }

        [Fact]
        public void SuceedsWhenFalse()
        {
            var sut = GetSut("a", "para");

            sut.False(val => val.Equals("b"));
        }
    }
}