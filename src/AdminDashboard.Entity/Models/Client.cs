using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Models;

public class Client : IdentityUser, IEntity
{
    [Key]
    [JsonPropertyName("client_id")]
    public int Id { get; set; }

    [Required]
    [JsonPropertyName("client_name")]
    public string Name { get; set; }


    [Required]
    [JsonPropertyName("password")]
    public string Password { get; set; }
}