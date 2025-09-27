using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ZiyandaMnqwaziPortfolio.Repositories
{
    public class SqlDataAccess: ISqlDataAccess
    {
        private readonly IConfiguration _config;

            public SqlDataAccess(IConfiguration config)
            {
                _config = config;
            }

            public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connection = "DefaultConnection")
            {
                using IDbConnection con = new SqlConnection(_config.GetConnectionString(connection));
                return await con.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }

            public async Task<int> SaveData<T>(string spName, T parameters, string connection = "DefaultConnection")
            {
                using IDbConnection con = new SqlConnection(_config.GetConnectionString(connection));
                return await con.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
            }

            public async Task<int> GetSingleValue<T, P>(string spName, P parameters, string connection = "DefaultConnection")
            {
                using IDbConnection con = new SqlConnection(_config.GetConnectionString(connection));
                return await con.QuerySingleOrDefaultAsync<int>(spName, parameters, commandType: CommandType.StoredProcedure);
            }

            public async Task<IEnumerable<T>> GetData<T>(string query, object parameters, string connection = "DefaultConnection")
            {
                using IDbConnection con = new SqlConnection(_config.GetConnectionString(connection));
                return await con.QueryAsync<T>(query, parameters);
            }
        }
    

}

