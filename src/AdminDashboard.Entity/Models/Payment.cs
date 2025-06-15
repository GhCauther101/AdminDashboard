using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Models;

public class Payment : IEntity
{
    [Key]
    [JsonPropertyName("payment_id")]
    public int Id { get; set; }

    [Required]
    [JsonPropertyName("source_client_id")]
    public int SourceClientId { get; set; }

    [Required]
    [JsonPropertyName("source_client")]
    public Client SourceClient { get; set; }

    [Required]
    [JsonPropertyName("destination_client_id")]
    public int DestinationClientId { get; set; }

    [Required]
    [JsonPropertyName("destination_client")]
    public Client DestinationClient { get; set; }

    [Required]
    [JsonPropertyName("process_time")]
    public DateTime ProcessTime { get; set; }
}