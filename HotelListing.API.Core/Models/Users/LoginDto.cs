using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using HotelListing.API.Data;

namespace HotelListing.API.Core.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your Passwor is Limited to {2} to {1} characters",
            MinimumLength = 6)]
        public string Password { get; set; }
    }
}
