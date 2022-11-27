using Blogi.Application.Features.Contract.Dtos.Get;

namespace Blogi.Application.Features.Contact.Commands.Create
{
    public class CreateContactCommand : IRequest<BaseCommandResponse<GetContactOutput>>
    {
        public int LanguageId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Content { get; set; }
    }
}