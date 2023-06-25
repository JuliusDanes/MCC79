using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controllers}")]
public class RolesController : BaseController<Role>
{
    public RolesController(IRoleRepository repository) : base(repository)
    {
    }
}