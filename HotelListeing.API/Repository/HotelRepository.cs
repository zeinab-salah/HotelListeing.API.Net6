using HotelListeing.API.Contract;
using HotelListeing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListeing.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelListeingDbContext _context;
        public HotelRepository(HotelListeingDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
