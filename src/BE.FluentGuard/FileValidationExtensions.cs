using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BE.FluentGuard
{
    public static class FileValidationExtensions
    {
        public static ValidationRule<string> FileExists(this ValidationRule<string> rule, string message = "File must exist")
        {
            rule.NotNullOrWhiteSpace();

            if (!File.Exists(rule.Value))
            {
                throw new FileNotFoundException(message, rule.Value);
            }
            return rule;
        }

        public static ValidationRule<string> DirectoryExists(this ValidationRule<string> rule, string message = null)
        {
            rule.NotNullOrWhiteSpace();

            if (!File.Exists(rule.Value))
            {
                if (message == null)
                {
                    message = $"Directory \"{rule.Value}\" must exist";
                }
                throw new DirectoryNotFoundException(message);
            }
            return rule;
        }
    }
}
