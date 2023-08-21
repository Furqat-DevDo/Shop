using EfCore.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration_user.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [StringValidator()]
    public string FullName { get; set; }
    [PasswordPropertyText]
    public string Password   { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public int PhoneNumber { get; set; }
    public DateTime UpdatedTime { get; internal set; }
}
