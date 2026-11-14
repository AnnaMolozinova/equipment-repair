using backend.Dtos;
using backend.Models;

namespace backend.Services;

public interface ITicketService
{
    IEnumerable<Ticket> GetAll();
    Ticket? GetById(int id);
    Ticket Create(CreateTicketRequest request);
    bool Assign(int id, int assigneeUserId);
    bool ChangeStatus(int id, string status);
}