using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class SkillService(IContext _context) : ICRUD<Skill>
{
    public async Task<Response<List<Skill>>> GetAll()
    {
        var sql = @"select * from skills";
        var res = await _context.Connection().QueryAsync<Skill>(sql);
        return new Response<List<Skill>>(res.ToList());
    }

    public async Task<Response<Skill>> GetAllByID(int id)
    {
        var sql = @"select * from skills where skillid = @id";
        var res = await _context.Connection().QuerySingleOrDefaultAsync<Skill>(sql, new { id });
        return new Response<Skill>(res);
    }

    public async Task<Response<bool>> Add(Skill entity)
    {
        var sql =
            @"insert into skills (UserId, Title, Description, CreatedAt) values (@UserId, @Title, @Description, @CreatedAt);)";
        var res = await _context.Connection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Skill added successfully");
    }

    public async Task<Response<bool>> Update(Skill entity)
    {
        var sql = 
            @"update skills set UserId=@UserId, Title = @Title, Description = @Description, CreatedAt = @CreatedAt where skillid = @skillid";
        var res = await _context.Connection().ExecuteAsync(sql, entity);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Skill update successfully");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = @"delete from skills where skillid = @skillid";
        var res = await _context.Connection().ExecuteAsync(sql, new { skillid = id });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Skill deleted successfully");
    }
}