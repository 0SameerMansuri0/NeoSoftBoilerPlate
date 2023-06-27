using AutoMapper;
using EMartProject.Configuration;
using EMartProject.Context;
using EMartProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EMartProject.Authorization
{
    public class AuthManager : IAuthManager
    {
        readonly IConfiguration _configuration; 
        readonly UserManager<User> _userManager;
        readonly IMapper _mapper;
        public User _user;
        private const string _loginProvider = "HotelApi";
        private string _refreshToken = "RefreshToken";
        public AuthManager(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<AuthResponse> Login(LoginDto loginDto)
        {
            #region
            /*bool isValidUser=false;
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                isValidUser=await _userManager.CheckPasswordAsync(user, loginDto.Password);
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
            return isValidUser;*/
            #endregion
            var user=await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser=await _userManager.CheckPasswordAsync(user, loginDto.Password);
            var token =await GenerateToken(user);
            return new AuthResponse()
            { 
                UserId = user.Id,
                Token=token,
                // RefreshToken = await CraeteRefreshToken()
            };
        }

        private async Task<string> GenerateToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Email,user.Email),
                 new Claim("uid",user.Id)

            }
            .Union(userClaims).Union(roleClaims);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWTSettings:Issuer"],
                audience: _configuration["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt64(_configuration["JWTSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(UserDto userDto)
        {
           var user=_mapper.Map<User>(userDto);
            user.UserName = userDto.Email;
           var result= await _userManager.CreateAsync(user,userDto.Password);
            if(result.Succeeded)
            {
               var res = _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;

        }


        public async Task<string> CraeteRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newrefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newrefreshToken);
            return newrefreshToken;
        }

        public async Task<AuthResponse> VerifyRefreshToken(AuthResponse request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var userName = tokenContent.Claims.ToList().FirstOrDefault(t => t.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByNameAsync(userName);
            if (_user == null || _user.Id != request.UserId)
            {
                return null;

            }
            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);
            if (isValidRefreshToken)
            {
                var token = await GenerateToken(_user);
                return new AuthResponse
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CraeteRefreshToken()
                };
            }
            //await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }
    }
}
