using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_WPF.Models.Users;

public class AuthenticateRequest
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}
