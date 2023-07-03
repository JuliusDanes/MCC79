using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(MCC79DbContext context) : base(context) { }

        public ICollection<AccountRole> GetByGuidEmployee(Guid employeeGuid)
        {
            return _context.Set<AccountRole>().Where(a => a.AccountGuid == employeeGuid).ToList();
        }
    }
}

