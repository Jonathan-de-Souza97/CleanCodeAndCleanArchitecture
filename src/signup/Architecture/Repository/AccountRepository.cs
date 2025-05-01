using signup.Application.Responses;
using signup.Architecture.Interface;
using signup.Domain.Entity;
using Dapper;
using signup.Architecture.Configuration;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace signup.Architecture.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ContextBase _context;
        public AccountRepository(ContextBase context)
        {
            _context = context;
        }
        public async Task<Response<Account>> AddAsync(Account input)
        {
            var sql = $@"INSERT INTO account
                        (accountId, name, email, document, password)
                        VALUES
                        (@accountId, @name, @email, @document, @password)";

            try
            {
                var connection = await _context.Connection();

                await connection.ExecuteAsync(sql, new { input.accountId, input.name, input.email, input.document, input.password }, commandTimeout:1000);

                return Response<Account>.Success(input);
            }
            catch (Exception ex)
            {
                return Response<Account>.Error(ex.Message);
            }
        }        

        public async Task<Response<Account>> GetByIdAsync(Guid id)
        {
            var sql = $@"SELECT * FROM account
                         WHERE accountId = @id";

            try
            {
                var connection = await _context.Connection();

                var account = await connection.QueryFirstOrDefaultAsync<Account>(sql, new {id});

                return Response<Account>.Success(account);
            }
            catch (Exception ex)
            {
                return Response<Account>.Error(ex.Message);
            }
        }

        public async Task<Response<Account>> GetByDocument(string document)
        {
            var sql = $@"SELECT * FROM account
                         WHERE document = @document";

            try
            {
                var connection = await _context.Connection();

                var account = await connection.QueryFirstOrDefaultAsync<Account>(sql, new { document });

                return Response<Account>.Success(account);
            }
            catch (Exception ex)
            {
                return Response<Account>.Error(ex.Message);
            }
        }

        public async Task<Response<Account>> GetByEmail(string email)
        {
            var sql = $@"SELECT * FROM account
                         WHERE email = @email";

            try
            {
                var connection = await _context.Connection();

                var account = await connection.QueryFirstOrDefaultAsync<Account>(sql, new { email });

                return Response<Account>.Success(account);
            }
            catch (Exception ex)
            {
                return Response<Account>.Error(ex.Message);
            }
        }
    }
}
