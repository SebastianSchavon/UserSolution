using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_WPF.Helpers;

namespace User_WPF.Models.Users;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Species Species { get; set; }
    public ShipRole ShipRole { get; set; }
}
