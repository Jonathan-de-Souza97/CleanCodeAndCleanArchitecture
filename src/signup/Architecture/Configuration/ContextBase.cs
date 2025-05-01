using Npgsql;
using System.Data;

namespace signup.Architecture.Configuration
{
    public class ContextBase
    {
        private readonly string _connectionString;
        public ContextBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IDbConnection> Connection()
        {
            var connection = new NpgsqlConnection(_connectionString);

            await connection.OpenAsync();

            return connection;
        }
    }
}
