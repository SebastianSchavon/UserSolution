namespace User_ASP.Models.Users;

using System.ComponentModel.DataAnnotations;
using User_ASP.Entities;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public Species Species { get; set; }

    [Required]
    public string Password { get; set; }
}
