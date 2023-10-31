using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Dtos
{
    public class UserDto : IdentityUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
