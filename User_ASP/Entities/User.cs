namespace User_ASP.Entities;

using System.Text.Json.Serialization;


public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public Species Species { get; set; }
    public ShipRole ShipRole { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

}

public enum Species
{
    Human,
    Klingon, 
    Vulcan,
    Borg
}

public enum ShipRole
{
    Captain,
    Engineer,
    Helmsman,
    TacticalOfficer
}

