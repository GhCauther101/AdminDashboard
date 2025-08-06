using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Models;

public class Client : IdentityUser, IEntity
{
    [Key]
    public override string Id { get => base.Id; set => base.Id = value; }
    
    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; }

    [Required]
    [JsonPropertyName("sent_payments")]
    public ICollection<Payment> SentPayments { get; set; } = new List<Payment>();

    [Required]
    [JsonPropertyName("recieved_payments")]
    public ICollection<Payment> RecievedPayments { get; set; } = new List<Payment>();
}