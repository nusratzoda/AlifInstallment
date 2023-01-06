using Domain.Entities;

namespace Domain.Dtos;

public class AddCustomerDto
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? PhoneNumber { get; set; }
}