using signup.Application.DTOS;
using signup.Application.Responses;

namespace signup.Application.Interfaces
{
    public interface ISignup
    {
        Task<Response<AccountDTO>> Execute(InputSignup input);
    }
}
