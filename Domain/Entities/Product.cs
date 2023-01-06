namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int Price { get; set; }

    public virtual List<Installment>? Installments { get; set; }
}