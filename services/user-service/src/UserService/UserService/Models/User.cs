namespace UserService.Models;

public class User
{
    public Guid Id { get; set; }
    public string email { get; set; }
    public string password_hash { get; set; }
    public string username { get; set; }
    public string[] roles { get; set; }
    public DateTime created_at { get; set; }
}