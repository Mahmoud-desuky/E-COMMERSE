using Back.Core.Entities.Identity;

namespace Back.Infrastracture.Interface
{
    public interface ITokenService
    {
        string CreateteToken(User user);
    }
}