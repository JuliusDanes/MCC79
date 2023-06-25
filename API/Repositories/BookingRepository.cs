using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;

public class BookingRepository : BaseRepository<Booking>, IBookingRepository
{
    public BookingRepository(MCC79DbContext context) : base(context)
    {
    }
}