using Microsoft.EntityFrameworkCore;
using Registration.Data;
using Registration.Exceptions;
using Registration.Mappers;
using Registration.Models.Requests;
using Registration.Models.Responces;
using Registration.Services.Interfaces;

namespace Registration.Services;

public class UserService : IUserService
{
    private readonly RegDbContext _dbContext;

    public UserService(RegDbContext context)
    {
        _dbContext = context;
    }

    public async Task<GetUserResponse> CreateUserAsync(CreateUserRequest request)
    {
        var user = request.CreateUser();

        var newUser = await _dbContext.Users.AddAsync(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return newUser.Entity.ResponseUser();
    }

    public async Task<GetUserResponse> GetUserByEmailAddressAsync(LogInByEmailAddressUserRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.EmailAddress == request.EmailAddress);
        if (user is null)
            throw new InvalidDataGivenException($"User with email address: {request.EmailAddress} Not Found !!!");

        if(!user.CheckPassword(request.Password))
            throw new InvalidDataGivenException($"Given password is incorrect. Please enter again !!!");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> GetUserByPhoneNumberAsync(LogInByPhoneNumberUserRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber == request.PhoneNumber);
        if (user is null)
            throw new InvalidDataGivenException($"User with phone number: {request.PhoneNumber} Not Found !!!");

        if (!user.CheckPassword(request.Password))
            throw new InvalidDataGivenException($"Given password is incorrect. Please enter again !!!");

        return user.ResponseUser();
    }

    public async Task<GetUserResponse> UpdateUserAsync(UpdateUserRequest request)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(f => f.FullName == request.UserAuthData ||
                                 f.EmailAddress == request.UserAuthData  ||
                                 f.PhoneNumber == request.UserAuthData );

        if (user is null)
            throw new UserNotFoundException($"No such user : {request.UserAuthData}");

        user.UpdateUserPassword(request);
        _dbContext.Users.Update(user);

        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");

        return user.ResponseUser();
    }
}
