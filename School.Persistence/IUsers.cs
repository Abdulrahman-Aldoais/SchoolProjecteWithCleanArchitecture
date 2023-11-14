using School.Domain.Enum;
using SchoolProject.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Persistence
{
    public interface IUsers
    {
        //int Id { get; set; }
        //string Name { get; set; }
        //DateTime CreateTime { get; set; }
        //Status Status { get; set; }


        int Id { get; set; }
        string FullName { get; set; }
        string? Address { get; set; }
        string? Country { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        DateTime CreateTime { get; set; }
        Status Status { get; set; }
        [InverseProperty(nameof(UserRefreshToken.user))]
        ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
