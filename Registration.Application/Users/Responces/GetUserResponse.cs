namespace Registration.Application.Users.Responces;

public class GetUserResponse
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? EmailAddress { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
}
