namespace Registration_user.UserModel.Response
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PhoneNumber { get; set; }
    }
}
