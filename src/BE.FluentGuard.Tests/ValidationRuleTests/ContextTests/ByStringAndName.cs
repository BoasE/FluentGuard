// ==========================================================================
// ByStringAndName.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

namespace BE.FluentGuard.Tests.ValidationRuleTests.ContextTests
{
    public sealed class ByStringAndName : ContextTests<string>
    {
        protected override string ExpectedValue => "AA";

        protected override string ExpectedMemberName => "BB";

        protected override ValidationRule<string> GetSut()
        {
            return Precondition.For(ExpectedValue, "BB");
        }
    }
}