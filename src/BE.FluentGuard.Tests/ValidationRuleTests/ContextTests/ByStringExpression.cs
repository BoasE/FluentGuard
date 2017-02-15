// ==========================================================================
// ByStringExpression.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

namespace BE.FluentGuard.Tests.ValidationRuleTests.ContextTests
{
    public sealed class ByStringExpression : ContextTests<string>
    {
        protected override string ExpectedValue => "AA";

        protected override string ExpectedMemberName => "a";

        protected override ValidationRule<string> GetSut()
        {
            string a = ExpectedValue;
            return Precondition.For(() => a);
        }
    }
}