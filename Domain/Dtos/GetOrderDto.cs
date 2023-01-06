using Domain.Entities;

namespace Domain.Dtos;

public class GetOrderDto
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public int InstallmentId { get; set; }
    public int EndInstallment { get; set; }
}