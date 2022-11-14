using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using HotelListing.API.Data;

namespace HotelListing.API.Core.Models.Users
{
    public class ApiUserDto:LoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
      
    }
}
