using API.Utilities;
using API.Utilities.Enum;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Bookings;

public class NewBookingDto
{
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime StartDate { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EndDate { get; set; }
    [Required]
    [EnumDataType(typeof(StatusLevel), ErrorMessage = "Invalid status.")]
    public StatusLevel Status { get; set; }
    [Required]
    public string Remarks { get; set; }
    [Required]
    public Guid RoomGuid { get; set; }
    [Required]
    public Guid EmployeeGuid { get; set; }
}
