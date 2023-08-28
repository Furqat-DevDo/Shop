using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Registration.Core.Entities;

public class PasswordUpdate
{
    [Key]
    [ForeignKey("EmailAddress")]
    public string EmailAddress { get; set; } = null!;
    public string? NewPassword { get; set; }
}
