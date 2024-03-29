﻿using AutoMapper;
using HotelListeing.API.Contract;
using HotelListeing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListeing.API.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListeingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesRepository(HotelListeingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Country> GetDeails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

       
    }
}
