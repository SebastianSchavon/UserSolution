using User_ASP.Entities;

namespace User_ASP.Models.Users;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public Species Species { get; set; }
    public string Token { get; set; }
}
