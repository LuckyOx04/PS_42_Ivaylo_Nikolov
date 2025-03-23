using Welcome.Others;

namespace Welcome.Model;

public class User
{
    public int Id { get; set; }
    public DateTime Expires { get; set; }
    public string Names { get; set; }
    public string Password { get; set; }
    public string FacultyNumber { get; set; }
    public string Email { get; set; }
    public UserRolesEnum Role { get; set; }
}