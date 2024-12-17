using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services;
public class UserService(IContext _context):ICRUD<User>
{
    public async Task<Response<List<User>>> GetAll()
    {
        var sql = @"select * from Users";
        var res = await _context.Connection().QueryAsync<User>(sql);
        return new Response<List<User>>(res.ToList());
    }

    public async Task<Response<User>> GetAllByID(int id)
    {
        var sql = @"select * from Users where UserId = @id";
        var res = await _context.Connection().QuerySingleOrDefaultAsync<User>(sql, new { id });
        return new Response<User>(res);
    }

    public async Task<Response<bool>> Add(User entity)
    {
        var sql =
            @"insert into Users (FullName, Email, Phone, City,CreatedAt) values (@FullName, @Email, @Phone, @City, @CreatedAt)";
        var res = await _context.Connection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "User added successfully");
    }

    public async Task<Response<bool>> Update(User entity)
    {
        var sql = 
            @"update Users set FullName=@FullName, Email=@Email, Phone=@Phone, City=@City, CreatedAt=@CreatedAt where UserId = @UserId";
        var res = await _context.Connection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "User updated successfully");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = @"delete from Users where UserId = @id";
        var res = await _context.Connection().ExecuteAsync(sql, new { id });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "User deleted successfully");
    }
}