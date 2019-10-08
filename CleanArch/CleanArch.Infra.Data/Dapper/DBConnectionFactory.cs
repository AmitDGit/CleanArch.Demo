using System.Data;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace CleanArch.Infra.Data.Dapper
{
    public class DBConnectionFactory 
    {
        private IDbConnection _connection;
        private readonly IOptions<CleanArchConfigurations> _configs;

        public DBConnectionFactory(IOptions<CleanArchConfigurations> Configs)
        {
            _configs = Configs;
        }


        public IDbConnection GetConnection 
        {
            get
            {
                if (_connection is null)
                {
                    _connection = new SqlConnection(_configs.Value.UniversityDBConnection);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Open)
            {
                _connection.Close();
            }
        }

    }
}
