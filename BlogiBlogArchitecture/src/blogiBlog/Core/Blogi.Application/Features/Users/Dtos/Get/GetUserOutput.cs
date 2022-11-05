namespace Blogi.Application.Features.Users.Dtos.Get
{
    public class GetUserOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

    }
}
