namespace UserAPI.Domain;

public class Gender
{
    public int Id { get; set; }
    public string Label { get; set; }
    public bool IsDisabled { get; set; }
    public virtual ICollection<Gender> Genders { get; set; }
}