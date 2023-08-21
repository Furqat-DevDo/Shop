using Microsoft.EntityFrameworkCore;
using Registration_user.Data;
using Registration_user.Exeptions;
using Registration_user.Helper;
using Registration_user.Mapper;
using Registration_user.Services.Interfaces;
using Registration_user.UserModel.Request;
using Registration_user.UserModel.Response;


namespace Registration_user.Services;

public class UserService : IUserService
{
    public readonly PasswordEncryptDecryptHelper _passwordEncryptDecryptHelper;


    private readonly UserDbContext _dbContext;
    public UserService(UserDbContext dbContext, PasswordEncryptDecryptHelper passwordEncryptDecryptHelper)
    {
        _dbContext = dbContext;
        _passwordEncryptDecryptHelper = passwordEncryptDecryptHelper;
    }

    public async Task<GetUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var createUser = request.CreateUser();
        var newUser = await _dbContext.Users.AddAsync(createUser);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToCreateSaveChanges();

        return newUser.Entity.ResponseUser();

    }

    //public async Task<bool> DeleteAsync(string password)
    //{
    //    var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Password == password);
    //    if (user != null) throw new UserNotFoundExeption();

    //    _dbContext.Users.Remove(user);

    //    if (await _dbContext.SaveChangesAsync() > 0)
    //        throw new UnableToDeleteSaveChanges();

    //    return true;
    //}

    public async Task<GetUserResponse?> GetUserByEmailAsync(UserLogInByEmailRequest request)
    {
        var user = await _dbContext.Users
        .FirstOrDefaultAsync(f => f.Email == request.Email);

        if (user != null && _passwordEncryptDecryptHelper.CheckPassword(request.Password))
            throw new UserNotFoundExeption();

        return user.ResponseUser();
    }

    public async Task<GetUserResponse?> GetUserByPhoneNumberAsync(UserLogInByPhoneNumberRequest request)
    {
        var user = await _dbContext.Users
        .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber);
        if (user != null && _passwordEncryptDecryptHelper.CheckPassword(request.Password))
            throw new UserNotFoundExeption();

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserAsync(string password, UpdateUserRequest request)
    {
        var updatedUser = await _dbContext.Users.FirstOrDefaultAsync(b => b.Password == password);
        if (updatedUser is null)
            throw new UserNotFoundExeption();

        updatedUser.UpdateUser(request);

        if (await _dbContext.SaveChangesAsync() < 0)
            throw new UnableToUpdateSaveChanges();

        return updatedUser.ResponseUser();
    }
}
