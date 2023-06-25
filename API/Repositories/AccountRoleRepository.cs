﻿using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class AccountRoleRepository : BaseRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(MCC79DbContext context) : base(context)
    {
    }
}