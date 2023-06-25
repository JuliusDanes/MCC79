using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(MCC79DbContext context) : base(context)
    {
    }
}