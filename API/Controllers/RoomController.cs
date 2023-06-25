using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controllers}")]
public class RoomController : BaseController<Room>
{
    public RoomController(IRoomRepository repository) : base(repository)
    {
    }
}