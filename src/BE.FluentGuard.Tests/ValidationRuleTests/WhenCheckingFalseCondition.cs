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
            Assert.Throws<ArgumentException>(() => GetSut("a", "para").False(val => val.Equals("a")));
        }

        [Fact]
        public void SucceedsWhenFalse()
        {
            var sut = GetSut("a", "para");

            sut.False(val => val.Equals("b"));
        }
    }
}