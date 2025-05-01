using signup.Application.DTOS;
using signup.Application.Interfaces;
using signup.Application.Responses;
using signup.Architecture.Interface;
using signup.Domain.Validate.AccountValidation;

namespace signup.Application.UseCase
{
    public class Signup : ISignup
    {
        private readonly IAccountRepository _accountRepository;

        public Signup(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Response<AccountDTO>> Execute(InputSignup input)
        {
            var nameIsValid = ValidateName.Execute(input.Name);
            if (!nameIsValid) return Response<AccountDTO>.Error("Name invalid");

            var emailIsValid = ValidateEmail.Execute(input.Email);
            if (!emailIsValid) return Response<AccountDTO>.Error("Email invalid");

            var documentInvalid = ValidateCPF.Execute(input.Document);
            if (!documentInvalid) return Response<AccountDTO>.Error("CPF invalid");

            var passwordIsValid = ValidatePassword.Execute(input.Password);
            if (!passwordIsValid) return Response<AccountDTO>.Error("Password invalid");

            var getUserDocument = await _accountRepository.GetByDocument(input.Document);

            if (getUserDocument.Data != null) return Response<AccountDTO>.Error("CPF already registered");

            var getUserEmail = await _accountRepository.GetByEmail(input.Email);

            if (getUserEmail.Data != null) return Response<AccountDTO>.Error("Email already registered");

            var account = input.ToEntity();

            var addUser = await _accountRepository.AddAsync(account);

            if (!addUser.Sucess) return Response<AccountDTO>.Error("Error to create user");

            var dto = new AccountDTO
            {
                name = addUser.Data.name,
                email = addUser.Data.email,
                document = addUser.Data.document
            };
            return Response<AccountDTO>.Success(dto);
        }
    }
}
