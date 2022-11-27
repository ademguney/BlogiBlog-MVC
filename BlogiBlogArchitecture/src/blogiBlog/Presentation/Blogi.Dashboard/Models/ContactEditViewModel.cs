using Blogi.Application.Features.Contacts.Dtos.Get;
using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Dashboard.Models
{
    public class ContactEditViewModel
    {
        public List<GetListLanguageOutput> LanguageList { get; set; }
        public GetContactOutput Contact { get; set; }
    }
}