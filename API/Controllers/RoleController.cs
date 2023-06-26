using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/roles")]
public class RolesController : GeneralController<Role>
{
    public RolesController(IRoleRepository repository) : base(repository)
    {
    }
}