using Designophy.Entities;

namespace Designophy.Infrastructure.Token
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(User user);
    }
}
