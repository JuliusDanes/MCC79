using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Rooms;

public class NewRoomDto
{
    public string Name { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Floor { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Capacity { get; set; }
}
