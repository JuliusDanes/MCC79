using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories;

public class RoleRepository: GeneralRepository<Role>, IRoleRepository
{
    public RoleRepository(MCC79DbContext  dbContext) : base(dbContext) { }
}
