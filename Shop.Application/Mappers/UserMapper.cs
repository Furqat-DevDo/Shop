using Registration.Helpers;
using Registration.Models.Requests;
using Registration.Models.Responces;
using Registration.Services;
using Shop.Application.Models.Requests;
using Shop.Core.Entities;

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
            Password = user.Password,
            CreatedTime = user.CreatedTime,
            UpdatedTime = user.UpdatedTime
        };

    public static User CreateUser(this CreateUserRequest request)
        => new User
        {
            FullName = request.FullName,
            EmailAddress = request.EmailAddress,
            PhoneNumber = request.PhoneNumber,
            Password = PasswordHashingHelper.HashSHA1Password(request.Password)
        };

    public static void UpdateUserPassword(this User user, UpdateUserPasswordRequest request)
    {
        user.Password = PasswordHashingHelper.HashSHA1Password(request.NewPassword);
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static void UpdateUserAuthData(this User user, UpdateUserAuthDataRequest request)
    {
        switch (request.NameOfUserAuthData)
        {
            case "EmailAddress":
                user.EmailAddress = request.NewUserAuthData;
                break;
            case "PhoneNumber":
                user.PhoneNumber = request.NewUserAuthData;
                break;
            case "FullName":
                user.FullName = request.NewUserAuthData;
                break;
            default:
                throw new InvalidDataGivenException("Invalid Name of user auth data !!!");
        }
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static bool CheckPassword(this User user, string password)
        => user.Password == PasswordHashingHelper.HashSHA1Password(password);
}
