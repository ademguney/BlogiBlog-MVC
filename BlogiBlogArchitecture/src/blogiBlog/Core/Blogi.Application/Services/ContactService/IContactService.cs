using Blogi.Application.Features.Contact.Dtos.GetList;
using Blogi.Application.Features.Contract.Dtos.Get;

namespace Blogi.Application.Services.ContactService
{
    public interface IContactService
    {
        Task<List<GetListContactOutput>> GetListAsync();
        Task<GetContactOutput> GetAsync(int id);
    }
}