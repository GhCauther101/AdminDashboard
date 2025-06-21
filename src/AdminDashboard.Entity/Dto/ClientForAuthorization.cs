using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Entity.Dto;

public class ClientForAuthorization
{
    [Required(ErrorMessage = "User name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "User email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "User password is required")]
    public string Password { get; set; }
}