using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_WPF.Entities;

// why did Serializeable attribute?
[Serializable]
public class User
{
    public string Username { get; set; }
    public string Species { get; set; }
    public string Token { get; set; }

}
