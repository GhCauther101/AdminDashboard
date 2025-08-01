using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Models;

public class Payment : IEntity
{
    [Key]
    [JsonPropertyName("payment_id")]
    public Guid PaymentId { get; set; }

    [Required]
    [JsonPropertyName("source_client_id")]
    public string SourceClientId { get; set; }

    [Required]
    [JsonPropertyName("source_client_id")]
    public string DestinationClientId { get; set; }

    [Required]
    [JsonPropertyName("source_client")]
    public Client SourceClient { get; set; }

    [Required]
    [JsonPropertyName("destination_client")]
    public Client DestinationClient { get; set; }

    [Required]
    [JsonPropertyName("biil")]
    public decimal Bill { get; set; }

    [Required]
    [JsonPropertyName("process_time")]
    public DateTime ProcessTime { get; set; }
}