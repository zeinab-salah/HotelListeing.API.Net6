﻿using AutoMapper;
using HotelListeing.API.Contract;
using HotelListeing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListeing.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelListeingDbContext _context;
        private readonly IMapper _mapper;

        public HotelRepository(HotelListeingDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
    }
}
