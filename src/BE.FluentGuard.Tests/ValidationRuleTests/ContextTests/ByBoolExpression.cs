﻿// ==========================================================================
// ByBoolExpression.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

namespace BE.FluentGuard.Tests.ValidationRuleTests.ContextTests
{
    public sealed class ByBoolExpression : ContextTests<bool>
    {
        protected override bool ExpectedValue => true;

        protected override string ExpectedMemberName => "a";

        protected override ValidationRule<bool> GetSut()
        {
            bool a = ExpectedValue;
            return Precondition.For(() => a);
        }
    }
}