using EMartProject.Configuration;
using EMartProject.Models;
using Microsoft.AspNetCore.Identity;

namespace EMartProject.Authorization
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(UserDto userDto);

        Task<AuthResponse> Login(LoginDto loginDto);
    }
}
