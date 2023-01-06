using Domain.Entities;

namespace Domain.Dtos;

public class GetInstallmentDto
{
    public int Id { get; set; }
    public int EndInstallment { get; set; }
    public int Percentage { get; set; }

    public int ProductId { get; set; }
    public string? ProductName { get; set; }

    public virtual List<GetOrderDto>? Orders { get; set; }
}