using System;

namespace Domain.Entities;
    
public class Installment
{
    public int Id { get; set; }
    public int EndInstallment { get; set; }
    public int Percentage { get; set; }

    public int ProductId { get; set; }

    public virtual List<Order>? Orders { get; set; }
}