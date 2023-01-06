using Domain.Entities;

namespace Domain.Dtos;

public class AddOrderDto
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }
    public int InstallmentId { get; set; }
}