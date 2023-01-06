using Domain.Entities;

namespace Domain.Dtos;

public class GetCustomerDto
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual List<GetOrderDto>? Orders { get; set; }
}