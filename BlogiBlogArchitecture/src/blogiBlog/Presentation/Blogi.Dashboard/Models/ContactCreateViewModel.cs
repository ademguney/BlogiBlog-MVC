using Blogi.Application.Features.Contact.Commands.Create;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class ContactCreateViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public CreateContactCommand ContactCommand { get; set; }
    }
}