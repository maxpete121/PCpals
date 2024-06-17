namespace PCpals.Models;

public class Account : RepoItem<string>
{
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
  public string PhoneNumber{ get; set;}
}
