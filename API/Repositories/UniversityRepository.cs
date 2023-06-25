using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        public UniversityRepository(MCC79DbContext context) : base(context)
        {
        }
    }
}
