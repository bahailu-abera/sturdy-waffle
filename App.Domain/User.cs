namespace App.Domain;
using App.Domain.Common;

public class User : Base
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}