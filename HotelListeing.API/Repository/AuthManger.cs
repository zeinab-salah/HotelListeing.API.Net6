using AutoMapper;
using HotelListeing.API.Contract;
using HotelListeing.API.Data;
using HotelListeing.API.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelListeing.API.Repository
{
    public class AuthManger : IAuthManger
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private  ApiUser _user;

        private const string _loginProvider= "HotelListingAPI";
        private const string _refreshToken = "RefreshToken";

        public AuthManger(IMapper mapper, UserManager<ApiUser> userManager,IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager=userManager;
            this._configuration = configuration;
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user,_loginProvider,
                _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user,
               _loginProvider,_refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user,
               _loginProvider, _refreshToken,newRefreshToken);

            return newRefreshToken;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            bool isValidUser=false;
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);
            if (_user == null || isValidUser==false)
            {
               return null;
            }
            var token =await GenrateToken();
            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };

        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto) 
        {
            _user = _mapper.Map<ApiUser>(apiUserDto);
            _user.UserName = apiUserDto.Email;

            var result=await _userManager.CreateAsync(_user, apiUserDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }
             return result.Errors;

        }

        public async Task<AuthResponseDto> VerfiyRefreshToken(AuthResponseDto requset)
        {
            var jwtSecurityTokenHandler=new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(requset.Token);
            var username=tokenContent.Claims.ToList().FirstOrDefault(
                q=>q.Type==JwtRegisteredClaimNames.Email)?.Value;
            _user= await _userManager.FindByNameAsync(username);

            if (_user==null || _user.Id != requset.UserId)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user
                , _loginProvider,_refreshToken,requset.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenrateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken=await CreateRefreshToken()
                };
            }
            await _userManager.UpdateSecurityStampAsync(_user);

            return null;
        }

        private async Task<string> GenrateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            
            var roles=await _userManager.GetRolesAsync(_user);

            var roleClaims = roles.Select(x=> new Claim(ClaimTypes.Role,x)).ToList();
            
            var userClaims=await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id),
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration
                ["JwtSettings:DurationInMinutes"])),
                signingCredentials:credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
