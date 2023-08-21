using Registration.Models.Requests;
using Registration.Models.Responces;

namespace Registration.Services.Interfaces;

public interface IUserService
{
    Task<GetUserResponce> CreateUserAsync(CreateUserRequest request);
    Task<GetUserResponce> UpdateUserAsync(UpdateUserRequest request);
    Task<GetUserResponce> GetUserByEmailAddressAsync(string emailAddress, string password);
    Task<GetUserResponce> GetUserByPhoneNumberAsync(string phoneNumber, string password);

}
