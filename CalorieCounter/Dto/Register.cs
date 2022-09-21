using System.ComponentModel.DataAnnotations;

namespace CalorieCounter.Dto
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Passwords didn't match!")]
        public string ConfirmPassword { get; set; }
    }
}
