﻿using Microsoft.Build.Framework;
using HotelListing.API.Data;

namespace HotelListing.API.Core.Models.Hotel
{
    public class HotelDto : BaseHotelDto
    {
            public int Id { get; set; }   
    }
}