﻿using Registration.Helpers;
using Registration.Services;
using Shop.Application.Registrations.Requests;
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
            CreatedTime = user.CreatedTime,
            UpdatedTime = user.UpdatedTime
        };

    public static User CreateUser(this CreateUserRequest request)
       => new User
       {
           FullName = request.FullName,
           EmailAddress = request.EmailAddress,
           Password = PasswordHashingHelper.PasswordHashing(request.Password)
       };

    public static void UpdateUserPassword(this User user, UpdateUserPassRequest request)
    {
        user.Password = PasswordHashingHelper.PasswordHashing(request.NewPassword);
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static void UpdateUserData(this User user, UpdateUserDataRequest request)
    {
        user.FullName = request.NewFullName;
        user.EmailAddress = request.NewEmailAddress;
        user.UpdatedTime = DateTime.UtcNow;
    }

    public static bool CheckPassword(this User user, string password)
        => user.Password == PasswordHashingHelper.PasswordHashing(password);
}
