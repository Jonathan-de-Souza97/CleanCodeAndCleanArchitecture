using signup.Application.DTOS;
using signup.Application.Responses;
using signup.Domain.Entity;

namespace signup.Application.Interfaces
{
    public interface IGetUsers
    {
        Task<Response<List<AccountDTO>>> Execute();
    }
}
