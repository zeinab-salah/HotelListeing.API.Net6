using HotelListeing.API.Data;

namespace HotelListeing.API.Contract
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDeails(int id);
    }
}
