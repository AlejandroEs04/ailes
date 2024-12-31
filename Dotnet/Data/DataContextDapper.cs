using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Dotnet.Data;

class DataContextDapper
{
    private readonly IConfiguration _config;

    public DataContextDapper(IConfiguration config)
    {
        _config = config;
    }

    public IEnumerable<T> Query<T>(string sql, object? parameters = null)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Query<T>(sql, parameters);
    }

    public T? QuerySingle<T>(string sql, object? parameters = null)
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingleOrDefault<T>(sql, parameters);
    }

    public bool ExecuteSql(string sql, object? parameters = null) 
    {
        IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql, parameters) > 0;
    }
}