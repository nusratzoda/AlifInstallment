namespace Domain.Dtos;

public class GetProductDto
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int Price { get; set; }
}