using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories;

public class RoomRepository : GeneralRepository<Room>, IRoomRepository
{
    public RoomRepository(MCC79DbContext  dbContext) : base(dbContext) { }
}
