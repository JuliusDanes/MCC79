using API.Utilities;
using API.Utilities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Employees;

public class UpdateEmployeeDto
{
    [Required]
    public Guid Guid { get; set; }
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
    public DateTime HiringDate { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
}
