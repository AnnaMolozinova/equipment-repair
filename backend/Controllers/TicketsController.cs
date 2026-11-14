using Microsoft.AspNetCore.Mvc;
using backend.Dtos;
using backend.Services;
using backend.Models;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _service;
    private readonly ILogger<TicketsController> _logger;

    public TicketsController(ITicketService service, ILogger<TicketsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    // GET /api/tickets
    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    // GET /api/tickets/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var ticket = _service.GetById(id);
        if (ticket == null) return NotFound(new { message = "Заявка не найдена" });
        return Ok(ticket);
    }

    // POST /api/tickets
    [HttpPost]
    public IActionResult Create([FromBody] CreateTicketRequest request)
    {
        try
        {
            var created = _service.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateTicket failed for EquipmentId {EquipmentId}", request.EquipmentId);
            return Problem(statusCode: 500, title: "Не удалось обработать запрос");
        }
    }

    // PATCH /api/tickets/{id}/assignee
    [HttpPatch("{id}/assignee")]
    public IActionResult Assign(int id, [FromBody] AssignRequest request)
    {
        if (!_service.Assign(id, request.AssigneeUserId))
            return NotFound(new { message = "Заявка не найдена" });

        return Ok(new { message = "Исполнитель назначен" });
    }

    // PATCH /api/tickets/{id}/status
    [HttpPatch("{id}/status")]
    public IActionResult ChangeStatus(int id, [FromBody] StatusRequest request)
    {
        try
        {
            if (!_service.ChangeStatus(id, request.Status))
                return NotFound(new { message = "Заявка не найдена" });

            return Ok(new { message = "Статус изменен" });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}

// Вспомогательные классы для PATCH-запросов
public class AssignRequest { public int AssigneeUserId { get; set; } }
public class StatusRequest { public string Status { get; set; } = string.Empty; }