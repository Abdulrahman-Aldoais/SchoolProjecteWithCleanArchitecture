using Microsoft.AspNetCore.Identity;
using School.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }

        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string Task { get; set; }
        public bool RememberMe { get; set; }

        [InverseProperty(nameof(UserRefreshToken.user))]
        public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}