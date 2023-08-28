using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Core.Entities;

public class VerificationEntity
{
    [Key]
    [ForeignKey("EmailAddress")]
    public string EmailAddress { get; set; } = null!;
    public string Code { get; set; } = null!;
}
