using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories;

public class BookingRepository : GeneralRepository<Booking>, IBookingRepository
{
    public BookingRepository(MCC79DbContext  dbContext) : base(dbContext) { }

    public ICollection<Booking> GetBookingLength()
    {
        return _context.Set<Booking>().ToList();
    }
}
