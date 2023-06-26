using API.Models;
using API.Contracts;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/universities")]
    public class UniversityController : GeneralController<IUniversityRepository, University>
    {
        public UniversityController(IUniversityRepository repository) : base(repository)
        {
        }

        [HttpGet("by-name/{name}")]
        public IActionResult GetByName(string name)
        {
            var universities = _repository.GetByName(name);
            if (!universities.Any())
            {
                return NotFound(new ResponeHandler<University>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "No Universities found with the given name"
                });
            }
            return Ok(new ResponeHandler<IEnumerable
                <University>>
            { 
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Universities found",
                Data = universities
            });
        }
    }
}
