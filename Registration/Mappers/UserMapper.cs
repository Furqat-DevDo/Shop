using Registration.Entities;
using Registration.Helpers;
using Registration.Models.Requests;
using Registration.Models.Responces;

namespace Registration.Mappers;

public static class UserMapper
{
    public static GetUserResponse ResponseUser(this User user)
        => new GetUserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress,
            PhoneNumber = user.PhoneNumber,
            Password = PasswordEncryptDecryptHelper.DecryptPassword(user.Password),
            CreatedTime = user.CreatedTime,
            UpdatedTime = user.UpdatedTime
        };

    public static User CreateUser(this CreateUserRequest request)
        => new User
        {
            FullName = request.FullName,
            EmailAddress = request.EmailAddress,
            PhoneNumber = request.PhoneNumber,
            Password = PasswordEncryptDecryptHelper.EncryptPassword(request.Password)
        };

    public static void UpdateUserPassword(this User user, UpdateUserRequest request)
    {
        user.Password = PasswordEncryptDecryptHelper.EncryptPassword(request.NewPassword);
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static bool CheckPassword(this User user, string password)
        => PasswordEncryptDecryptHelper.DecryptPassword(user.Password) == password;
}
