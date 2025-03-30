using Back.Core.Entities.Identity;

namespace ECommerce.Repository.Interface
{
    public interface ITokenService
    {
        string CreateteToken(User user);
    }
}