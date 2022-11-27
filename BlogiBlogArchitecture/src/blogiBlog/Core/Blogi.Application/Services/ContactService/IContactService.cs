using Blogi.Application.Features.Contacts.Dtos.Get;
using Blogi.Application.Features.Contacts.Dtos.GetList;

namespace Blogi.Application.Services.ContactService
{
    public interface IContactService
    {
        Task<List<GetListContactOutput>> GetListAsync();
        Task<GetContactOutput> GetAsync(int id);
    }
}