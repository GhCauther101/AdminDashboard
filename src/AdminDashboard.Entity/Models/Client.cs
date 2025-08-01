using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Models;

public class Client : IdentityUser, IEntity
{
    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; }

    [Required]
    [JsonPropertyName("sent_payments")]
    public IEnumerable<Payment> SentPayments { get; set; }

    [Required]
    [JsonPropertyName("recieved_payments")]
    public IEnumerable<Payment> RecievedPayments { get; set; }
}