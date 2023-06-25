using API.Contracts;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controllers}")]
public class BookingController : BaseController<Booking>
{
    public BookingController(IBookingRepository repository) : base(repository)
    {
    }
}