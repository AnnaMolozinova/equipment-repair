using backend.Dtos;
using backend.Models;

namespace backend.Services;

public class TicketService : ITicketService
{
    private readonly List<Ticket> _tickets = new();
    private int _nextId = 1;

    public IEnumerable<Ticket> GetAll() => _tickets;

    public Ticket? GetById(int id) => _tickets.FirstOrDefault(t => t.Id == id);

    public Ticket Create(CreateTicketRequest request)
    {
        var ticket = new Ticket
        {
            Id = _nextId,
            Number = $"REP-{_nextId:D3}",
            Title = request.Title,
            Description = request.Description,
            EquipmentId = request.EquipmentId,
            Status = "New",
            AssigneeUserId = null
        };

        _tickets.Add(ticket);
        _nextId++;
        return ticket;
    }

    public bool Assign(int id, int assigneeUserId)
    {
        var ticket = GetById(id);
        if (ticket == null) return false;

        ticket.AssigneeUserId = assigneeUserId;
        return true;
    }

    public bool ChangeStatus(int id, string status)
    {
        var ticket = GetById(id);
        if (ticket == null) return false;

        // Правило процесса: нельзя в работу без исполнителя
        if (status == "InProgress" && ticket.AssigneeUserId == null)
        {
            throw new InvalidOperationException("Нельзя взять в работу заявку без исполнителя.");
        }

        ticket.Status = status;
        return true;
    }
}