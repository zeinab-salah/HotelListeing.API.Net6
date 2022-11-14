using HotelListing.API.Data;

namespace HotelListing.API.Core.Contarct
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDeails(int id);
    }
}
