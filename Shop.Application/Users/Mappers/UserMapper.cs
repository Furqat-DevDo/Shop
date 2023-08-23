using Registration.Helpers;
using Registration.Services;
using Shop.Application.Registrations.Models;
using Shop.Application.Users.Requests;
using Shop.Application.Users.Responces;
using Shop.Core.Entities;

namespace Shop.Application.Users.Mappers;

public static class UserMapper
{
    public static GetUserResponse ResponseUser(this User user)
        => new GetUserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress,
            PhoneNumber = user.PhoneNumber,
            CreatedTime = user.CreatedTime,
            UpdatedTime = user.UpdatedTime
        };

    public static User CreateUser(this RegisterRequest request)
        => new User
        {
            FullName = request.FullName,
            EmailAddress = request.EmailAddress,
            PhoneNumber = request.PhoneNumber,
            Password = PasswordHashingHelper.HashSHA1Password(request.Password)
        };

    public static void UpdateUserPassword(this User user, UpdateUserPassRequest request)
    {
        user.Password = PasswordHashingHelper.HashSHA1Password(request.NewPassword);
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static void UpdateUserName(this User user, UpdateUserNameRequest request)
    {
        user.FullName = request.FullName;
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static void UpdateUserEmail(this User user, UpdateUserEmailRequest request)
    {
        user.EmailAddress = request.EmailAddress;
        user.UpdatedTime = DateTime.UtcNow;
    }
    public static void UpdateUserPhone(this User user, UpdateUserPhoneRequest request)
    {
        user.PhoneNumber = request.PhoneNumber;
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static bool CheckPassword(this User user, string password)
        => user.Password == PasswordHashingHelper.HashSHA1Password(password);
}
