using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.API.Data.Configrations
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
