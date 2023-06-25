using API.Models;
using API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controllers}")]
    public class UniversityController : BaseController<University>
    {
        public UniversityController(IUniversityRepository repository) : base(repository)
        {
        }
    }
}
