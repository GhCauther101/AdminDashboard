namespace AdminDashboard.Entity.Models;

public class Snap : IEntity
{
    public int ClientsCount { get; set; }
    
    public int PaymentsCount { get; set; }

    public decimal PaymentsTotalBill { get; set; }
}
