using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Entities;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FullName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedTime { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
}
