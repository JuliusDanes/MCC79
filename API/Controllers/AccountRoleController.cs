using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controllers}")]
public class AccountRoleController : BaseController<AccountRole>
{
    public AccountRoleController(IAccountRoleRepository repository) : base(repository)
    {
    }
}