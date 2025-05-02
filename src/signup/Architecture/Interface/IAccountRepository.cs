using signup.Application.Responses;
using signup.Domain.Entity;

namespace signup.Architecture.Interface
{
    public interface IAccountRepository
    {
        Task<Response<Account>> AddAsync(Account input);

        Task<Response<Account>> GetByIdAsync(Guid id);

        Task<Response<Account>> GetByEmail(string email);

        Task<Response<Account>> GetByDocument(string document);
        Task<Response<List<Account>>> GetUsers();
    }
}
