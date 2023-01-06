namespace Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual List<Order>? Orders { get; set; }
}