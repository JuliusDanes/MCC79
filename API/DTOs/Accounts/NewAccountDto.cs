using API.Utilities;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Accounts;

public class NewAccountDto
{
    [Required]
    [PasswordPolicy]
    public string Password { get; set; }
    [Required]
    public bool IsDeleted { get; set; }
    [Required]
    public int Otp { get; set; }
    [Required]
    public bool IsUsed { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime ExpiredTime { get; set; }
}
