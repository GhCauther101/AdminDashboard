namespace AdminDashboard.Entity.Models;

public class Snap : IEntity
{
    public int ClientCount { get; set; }

    public int PaymentCount { get; set; }

    public decimal TotalBill { get; set; }

    public decimal AverageBill { get; set; }
}