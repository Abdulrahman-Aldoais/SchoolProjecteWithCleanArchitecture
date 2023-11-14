﻿using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities;

namespace School.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {

        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; }

        public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

        public ApplicationUser()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
        }
    }

}