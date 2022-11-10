using HotelListeing.API.Models.Hotel;

namespace HotelListeing.API.Models.Country
{
    public class CountryDto:BaseCountryDto
    {
        public int Id { get; set; }

        public List<HotelDto> Hotels { get; set; }
    }
}
