namespace UserAPI.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public int GenderId { get; set; }
    public string? RefreshToken { get; set; }
    public virtual Gender Gender { get; set; }
    public virtual Role Role { get; set; }
}