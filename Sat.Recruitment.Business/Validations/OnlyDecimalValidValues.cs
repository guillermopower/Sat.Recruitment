using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Business.Validations
{
    public class OnlyDecimalValidValues : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value.ToString();
            if (string.IsNullOrEmpty(str)) return null;

            var IsValidDecimal = (decimal)value > 0 && (decimal) value < decimal.MaxValue;
            if (!IsValidDecimal)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return RegularExpressionValidation.WordReserved(str) > -1 ? new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName)) : null;
        }
    }
}
