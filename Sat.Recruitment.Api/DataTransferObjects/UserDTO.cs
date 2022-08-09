using Sat.Recruitment.Business.Validations;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.DataTransferObjects
{
    public class UserDTO
    {
        [OnlyLettersAndNumbers(ErrorMessage = "Characters Not Allowed")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [OnlyLettersAndNumbers(ErrorMessage = "Characters Not Allowed")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [OnlyUsersTypesAllowed(ErrorMessage = "User Type Not Allowed")]
        [Required(ErrorMessage = "UserType is required.")]
        public string UserType { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Money is required.")]
        public decimal Money { get; set; }
    }
}