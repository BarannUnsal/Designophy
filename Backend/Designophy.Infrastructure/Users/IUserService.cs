using Designophy.WebModels.Requests;
using Microsoft.AspNetCore.Identity;

namespace Designophy.Infrastructure.Users
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(CreateUserRequest request);

        Task<string> LoginAsync(LoginRequest request);
    }
}
