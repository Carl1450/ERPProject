using System.Data;
using Dapper;
using ERPProject.Models;
using Npgsql;


namespace ERPProject.Database;

public class UserDb
{
    private readonly IConfiguration _configuration;
    
    public UserDb(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    private IDbConnection Connection 
        => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));

    public async Task<User?> GetByUsernameAsync(string username)
    {
        using var conn = Connection;
        var sql = "SELECT * FROM Users WHERE Username = @Username";
        return await conn.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
    }
}