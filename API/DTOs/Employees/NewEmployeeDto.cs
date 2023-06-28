using API.Utilities;
using API.Utilities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace API.DTOs.Employees;

public class NewEmployeeDto
{
    [Required]
    [Range(0, int.MaxValue)]
    public string Nik { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }
    [Required]
    [EnumDataType(typeof(GenderEnum), ErrorMessage = "Invalid gender.")]
    public GenderEnum Gender { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime HiringDate { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    [Required]
    [PasswordPolicy]
    public string Password { get; set; }
    [Required]
    [PasswordPolicy]
    [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Not Matched")]
    public string ConfirmPassword { get; set; }
}
