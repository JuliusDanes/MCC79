﻿using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controllers}")]
public class AccountController : BaseController<Account>
{
    public AccountController(IAccountRepository repository) : base(repository)
    {
    }    
}