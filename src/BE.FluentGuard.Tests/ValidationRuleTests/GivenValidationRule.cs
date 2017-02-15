// ==========================================================================
// GivenValidationRule.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

namespace BE.FluentGuard.Tests.ValidationRuleTests
{
    public class GivenValidationRule
    {
        protected virtual ValidationRule<T> GetSut<T>(T value, string name)
        {
            return Precondition.For(value, name);
        }
    }
}