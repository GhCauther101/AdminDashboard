using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Event.Base;

public class EventEntry(Guid Id, string Snap)
{
    [Key]
    [Required]
    [JsonPropertyName("event_entry_id")]
    public Guid Id { get; set; }
        
    [Required]
    [JsonPropertyName("snap")]
    public string Snap { get; set; }
}