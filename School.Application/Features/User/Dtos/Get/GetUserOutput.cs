namespace School.Application.Features.User.Dtos.Get
{
    public class GetUserOutput
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string Password { get; set; }
    }
}
