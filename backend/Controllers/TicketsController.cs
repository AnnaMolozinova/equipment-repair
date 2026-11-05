using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    // Внедрение зависимости через конструктор (DI)
    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        return Ok(new { message = _ticketService.GetStatus() });
    }
}