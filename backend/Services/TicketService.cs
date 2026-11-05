namespace backend.Services;

public class TicketService : ITicketService
{
    public string GetStatus()
    {
        return "Сервис заявок готов к работе";
    }
}