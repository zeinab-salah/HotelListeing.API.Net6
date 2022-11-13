using HotelListeing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListeing.API.Contract
{
    public interface IAuthManger
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerfiyRefreshToken(AuthResponseDto requset);
       
    }
}
