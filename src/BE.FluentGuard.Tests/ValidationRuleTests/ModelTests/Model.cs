// ==========================================================================
// Model.cs
// ==========================================================================
// Copyright (c) Boas Enkler
// All rights reserved.
// ========================================================================== 

using System.ComponentModel.DataAnnotations;

namespace BE.FluentGuard.Tests.ValidationRuleTests.ModelTests
{
    public sealed class Model
    {
        [Required]
        public string Value { get; set; }
    }
}