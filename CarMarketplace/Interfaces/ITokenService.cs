using CarMarketplace.Models;

namespace CarMarketplace.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
