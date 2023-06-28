using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Rooms;

public class UpdateRoomDto
{
    [Required]
    public Guid Guid { get; set; }
    public string Name { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Floor { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int Capacity { get; set; }
}
