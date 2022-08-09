using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sat.Recruitment.Business.Validations
{
    public class OnlyUsersTypesAllowed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str)) return null;

            var match = GetUserTypes().Any(x => x.Contains(str));
            if (!match)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return RegularExpressionValidation.WordReserved(str) > -1 ? new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName)) : null;
        }

        public enum UserTypeEnum
        {
            Normal, SuperUser, Premium
        }

        public static List<string> GetUserTypes()
        {
            var types = Enum.GetNames(typeof(UserTypeEnum));
            return types.ToList();
        }
    }
}