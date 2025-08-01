using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Entity.Dto;

public class ClientForRegistration
{
    [Required(ErrorMessage = "Name is required")]
    [JsonProperty("username")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [JsonProperty("email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [JsonProperty("password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Roles is required")]
    [JsonProperty("roles")]
    public ICollection<string> Roles { get; set; }
}