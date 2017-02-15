// ==========================================================================
// ByBoolAndName.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

namespace BE.FluentGuard.Tests.ValidationRuleTests.ContextTests
{
    public sealed class ByBoolAndName : ContextTests<bool>
    {
        protected override bool ExpectedValue => true;

        protected override string ExpectedMemberName => "BB";

        protected override ValidationRule<bool> GetSut()
        {
            return Precondition.For(ExpectedValue, "BB");
        }
    }
}