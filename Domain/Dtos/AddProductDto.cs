using Domain.Entities;

namespace Domain.Dtos;

public class AddProductDto
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int Price { get; set; }
}