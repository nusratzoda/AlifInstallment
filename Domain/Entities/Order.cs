namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public int InstallmentId { get; set; }
    public virtual Installment? Installment { get; set; }
}