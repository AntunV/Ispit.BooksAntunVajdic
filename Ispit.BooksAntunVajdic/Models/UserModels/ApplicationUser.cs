using Ispit.BooksAntunVajdic.Models.Dbo;
using Microsoft.AspNetCore.Identity;

namespace Ispit.BooksAntunVajdic.Models.UserModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
