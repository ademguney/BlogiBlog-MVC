using Blogi.Application.Features.Users.Dtos.Get;

namespace Blogi.Dashboard.Models
{
    public class ProfileCreateViewModel
    {
        public GetUserOutput User { get; set; }
        public IFormFile File { get; set; }
    }
}