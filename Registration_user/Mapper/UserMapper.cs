using Registration_user.Entities;
using Registration_user.Helper;
using Registration_user.UserModel.Request;
using Registration_user.UserModel.Response; 

namespace Registration_user.Mapper;

public static class UserMapper
{
    //private static PasswordEncryptDecryptHelper passwordMapping = new();
    public static void UpdateUser(this User user, UpdateUserRequest request)
    {
        user.FullName = request.FullName;
        user.Email = request.Email;
        user.Password = request.Password;
        user.PhoneNumber = request.PhoneNumber;
    }

    public static User CreateUser(this CreateUserRequest request)
        => new User
        {
            FullName = request.FullName,
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
        };

    public static GetUserResponse ResponseUser(this User user)
    {
        return new GetUserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
    //public static void UpdateUserPassword(this User user, UpdateUserRequest request)
    //{
    //    user.Password = passwordMapping.EncryptPassword(request.Password);
    //    user.UpdatedTime = DateTime.UtcNow;
    //}

    //public static bool CheckPassword(this User user, string password)
    //    => passwordMapping.DecryptPassword(user.Password) == password;
}
