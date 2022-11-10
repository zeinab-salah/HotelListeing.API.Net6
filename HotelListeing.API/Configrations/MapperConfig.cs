using AutoMapper;
using HotelListeing.API.Data;
using HotelListeing.API.Models.Country;
using HotelListeing.API.Models.Hotel;

namespace HotelListeing.API.Configrations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreatCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
        }
    }
}
