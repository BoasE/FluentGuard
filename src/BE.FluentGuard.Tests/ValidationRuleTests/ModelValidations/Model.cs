using System.ComponentModel.DataAnnotations;

namespace BE.FluentGuard.Tests.ValidationRuleTests.ModelValidations
{
    public class Model
    {
        [Required]
        public string Foo { get; set; }
    }
}