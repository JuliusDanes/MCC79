using API.Utilities;
using API.Utilities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Accounts
{
    public class ForgetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "OTP must be a 6-digit number.")]
        public int Otp { get; set; }

        [Required]
        public DateTime ExpiredTime { get; set; }
    }
}
