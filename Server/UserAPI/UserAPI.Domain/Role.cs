namespace UserAPI.Domain;

public class Role
{
   public int Id { get; set; }
   public string Label { get; set; }
   public bool IsDisabled { get; set; }
   public virtual ICollection<User> Users { get; set; }
}