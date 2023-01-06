using Domain.Entities;

namespace Domain.Dtos;

public class AddInstallmentDto
{
    public int Id { get; set; }
    public int EndInstallment { get; set; }
    public int Percentage { get; set; }

    public int ProductId { get; set; }
}