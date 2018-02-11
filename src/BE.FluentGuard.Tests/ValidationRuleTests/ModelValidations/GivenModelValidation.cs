using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Xunit;

namespace BE.FluentGuard.Tests.ValidationRuleTests.ModelValidations
{
    public class GivenModelValidation : GivenValidationRule
    {
        [Fact]
        public void ItThrowsWhenAnnotationsAreNotValid()
        {
            var model = new Model();
            
            Assert.Throws<ValidationException>(()=>Precondition.For(model, nameof(model)).IsValidModel());
        }
        
        [Fact]
        public void ItSuceedsWhenRequirementsAreFullfilled()
        {
            var model = new Model {Foo = "aaa"};
            Precondition.For(model, nameof(model)).IsValidModel();
        }
    }
}