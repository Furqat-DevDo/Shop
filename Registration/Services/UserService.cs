using Registration.Data;
using Registration.Models.Requests;
using Registration.Models.Responces;
using Registration.Services.Interfaces;

namespace Registration.Services;

public class UserService : IUserService
{
    private readonly RegDbContext _context;

    public UserService(RegDbContext context)
    {
        _context = context;
    }

    public Task<GetUserResponce> CreateUserAsync(CreateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetUserResponce> GetUserByEmailAddressAsync(string emailAddress, string password)
    {
        throw new NotImplementedException();
    }

    public Task<GetUserResponce> GetUserByPhoneNumberAsync(string phoneNumber, string password)
    {
        throw new NotImplementedException();
    }

    public Task<GetUserResponce> UpdateUserAsync(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }
}
