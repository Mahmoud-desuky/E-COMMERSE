using Microsoft.AspNetCore.Identity;

namespace Back.Core.Entities.Identity
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}