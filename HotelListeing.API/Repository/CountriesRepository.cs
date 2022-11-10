using HotelListeing.API.Contract;
using HotelListeing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListeing.API.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListeingDbContext _context;
        public CountriesRepository(HotelListeingDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Country> GetDeails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
