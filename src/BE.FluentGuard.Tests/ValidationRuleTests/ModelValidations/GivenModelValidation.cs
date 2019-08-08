using System.ComponentModel.DataAnnotations;
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
        public void ItSucceedsWhenRequirementsAreFullfilled()
        {
            var model = new Model {Foo = "aaa"};
            Precondition.For(model, nameof(model)).IsValidModel();
        }
    }
}