using signup.Application.DTOS;
using signup.Application.Interfaces;
using signup.Application.Responses;
using signup.Architecture.Interface;
using signup.Domain.Entity;

namespace signup.Application.UseCase
{
    public class GetUsers : IGetUsers
    {
        private readonly IAccountRepository _accountRepository;

        public GetUsers(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Response<List<AccountDTO>>> Execute()
        {
            var accounts =  await _accountRepository.GetUsers();

            if (!accounts.Sucess) return Response<List<AccountDTO>>.Error("Error to get accounts");

            List <AccountDTO> accountsDTO = new List<AccountDTO>();


            foreach (var account in accounts.Data)
            {
                var accountDTO = new AccountDTO
                {
                    name = account.name,
                    email = account.email,
                    document = account.document
                };
                accountsDTO.Add(accountDTO);
            };

            return  Response<List<AccountDTO>>.Success(accountsDTO);
        }
    }
}
