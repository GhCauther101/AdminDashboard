namespace AdminDashboard.Entity.Dto;

public class PaymentDto
{
    public Guid Id { get; set; }

    public Guid SourceClientId { get; set; }

    public Guid DestinationClientId { get; set; }

    public decimal Bill { get; set; }

    public string ProcessTime { get; set; }
}
