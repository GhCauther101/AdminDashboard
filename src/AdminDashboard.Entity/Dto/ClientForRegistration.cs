using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Entity.Dto;

public class ClientForRegistration
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public ICollection<string> Roles { get; set; }
}
