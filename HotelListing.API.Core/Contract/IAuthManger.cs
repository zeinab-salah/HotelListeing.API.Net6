using Microsoft.AspNetCore.Identity;
using HotelListing.API.Data;
using HotelListing.API.Core.Models.Users;

namespace HotelListing.API.Core.Contarct
{
    public interface IAuthManger
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerfiyRefreshToken(AuthResponseDto requset);
       
    }
}
