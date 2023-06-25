using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controllers}")]
public class EducationController : BaseController<Education>
{
    public EducationController(IEducationRepository repository) : base(repository)
    {
    }
}