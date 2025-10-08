using System.ComponentModel.DataAnnotations;

namespace FEBookStoreManagement.DTO;

public class LoginDto
{
    [Required(ErrorMessage = "Enter your username")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Enter your password")]
    public string? Password { get; set; }
}