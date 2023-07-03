using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class RoomRepository : GeneralRepository<Room>, IRoomRepository
    {
        public RoomRepository(MCC79DbContext context) : base(context) { }

    }
}
