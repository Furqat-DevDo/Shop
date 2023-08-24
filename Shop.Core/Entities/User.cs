using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Core.Entities;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? FullName { get; set; } 
    public string? EmailAddress { get; set; } 
    public string? PhoneNumber { get; set; }
    [Required]
    public string Password { get; set; } = string.Empty!;
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
