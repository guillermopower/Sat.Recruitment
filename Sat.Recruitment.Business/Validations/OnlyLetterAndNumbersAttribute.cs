using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Business.Validations
{
    public class OnlyLettersAndNumbersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str)) return null;

            var match = Regex.Match(str, @"^[a-zA-Z0-9À-ÖØ-öø-ÿ\s\-\'\.]+$");
            if (!match.Success)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return RegularExpressionValidation.WordReserved(str) > -1 ? new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName)) : null;
        }
    }
}