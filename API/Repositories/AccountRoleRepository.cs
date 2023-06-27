using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    public AccountRoleRepository(MCC79DbContext  dbContext) : base(dbContext) { }
}
