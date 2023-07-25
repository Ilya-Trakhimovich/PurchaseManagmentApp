using Domain.Service.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Domain.Service.Services
{
    public interface IUserAuthRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userForRegistration);
        Task<bool> ValidateUserAsync(UserLoginDto loginDto);
        Task<string> CreateTokenAsync();
    }
}
