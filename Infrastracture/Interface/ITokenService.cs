using ECommerse.Core.Entities.Identity;

namespace ECommerse.Infrastracture.Interface
{
    public interface ITokenService
    {
        string CreateteToken(User user);
    }
}