namespace backend.Models;

public class Ticket
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int EquipmentId { get; set; }
    public string Status { get; set; } = "New";
    public int? AssigneeUserId { get; set; }
}