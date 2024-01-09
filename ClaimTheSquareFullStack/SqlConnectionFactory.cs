using System.Data.SqlClient;

namespace ClaimTheSquareFullStack
{
    public class SqlConnectionFactory
    {
        private string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
