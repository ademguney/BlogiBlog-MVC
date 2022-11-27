using Blogi.Application.Features.Contacts.Commands.Create;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class ContactCreateViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public CreateContactCommand ContactCommand { get; set; }
    }
}