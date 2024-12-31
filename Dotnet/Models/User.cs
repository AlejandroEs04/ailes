namespace Dotnet.Models;

public class User 
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime Birthdate { get; set; }
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public int RolId { get; set; }
    public virtual string Rol { get; set; } = "";
    public string? Company { get; set; }
    public string? Street { get; set; }
    public int ExtNumber { get; set; }
    public int IntNumber { get; set; } 
    public string? Neighborhood { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
}