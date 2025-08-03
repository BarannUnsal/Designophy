using Designophy.Entities;
using Designophy.Infrastructure.Token;
using Designophy.WebModels.Requests;
using Microsoft.AspNetCore.Identity;

namespace Designophy.Infrastructure.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> CreateUserAsync(CreateUserRequest request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email
            };

            // request.Password kullanılıyor
            var result = await _userManager.CreateAsync(user, request.Password);
            return result;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var signInResult = await _signInManager.CheckPasswordSignInAsync(
                user, request.Password, lockoutOnFailure: false);
            if (!signInResult.Succeeded) return null;

            return await _tokenService.CreateTokenAsync(user);
        }
    }
}
