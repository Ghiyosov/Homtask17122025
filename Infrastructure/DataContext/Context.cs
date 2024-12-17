using System.Data;
using Npgsql;

namespace Infrastructure.DataContext;

public interface IContext
{
    IDbConnection Connection();
}

public class Context : IContext
{
    
    readonly string _connectionString = 
            "Server=localhost; Port = 5432; Database = task; User Id = postgres; Password = 832111;";
    
    public IDbConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}