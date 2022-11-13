﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelListeing.API.Data.Configration
{
    public class CountryConfigration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
               new Country
               {
                   Id = 1,
                   Name = "Jamaica",
                   ShortName = "JM"
               }, new Country
               {
                   Id = 2,
                   Name = "Bahama",
                   ShortName = "BS"
               }, new Country
               {
                   Id = 3,
                   Name = "Cayman Island",
                   ShortName = "CI"
               }
               );

        }
    }
}
