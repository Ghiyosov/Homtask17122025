using System.Net;
using Dapper;
using Domein.Entities;
using Domein.Enums;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class RequestService(IContext _context) : ICRUD<Request>
{
    
    public async Task<Response<List<Request>>> GetAll()
    {
        var sql = @"select * from Requests";
        var res = await _context.Connection().QueryAsync<Request>(sql);
        return new Response<List<Request>>(res.ToList());
    }

    public async Task<Response<Request>> GetAllByID(int id)
    {
        var sql = @"select * from Requests where RequestId = @id";
        var res = await _context.Connection().QuerySingleOrDefaultAsync<Request>(sql, new { id });
        return new Response<Request>(res);
    }

    public async Task<Response<bool>> Add(Request entity)
    {
        var sql =
            @"insert into Requests(FromUserId, ToUserId, RequestSkillId, OfferedSkillId, Status, CreatedAt, UpdatedAt) 
                values (@FromUserId, @ToUserId, @RequestSkillId, @OfferedSkillId, @str, @CreatedAt, @UpdatedAt);";
        var res = await _context.Connection().ExecuteAsync(sql, 
            new{FromUserId=entity.FromUserId,ToUserId=entity.ToUserId,RequestSkillId=entity.RequestSkillId,
                OfferedSkillId=entity.OfferedSkillId,str = entity.Status.ToString(), CreatedAt=entity.CreatedAt, 
                UpdatedAt=entity.UpdatedAt});
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created,"Created Successfully");
    }

    public async Task<Response<bool>> Update(Request entity)
    {
        var sql = @"
            update Requests set FromUserId = @FromUserId, ToUserId = @ToUserId, RequestSkillId = @RequestSkillId,
                                OfferedSkillId=@OfferedSkillId, Status=@str, CreatedAt=@CreatedAt, UpdatedAt=@UpdatedAt
                                    where RequestId = @RequestId ";
        var res = await _context.Connection().ExecuteAsync(sql, 
            new{FromUserId=entity.FromUserId,ToUserId=entity.ToUserId,RequestSkillId=entity.RequestSkillId,
                OfferedSkillId=entity.OfferedSkillId,str = entity.Status.ToString(), CreatedAt=entity.CreatedAt, 
                UpdatedAt=entity.UpdatedAt, RequestId=entity.RequestId});
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK,"Update Successfully");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = @"delete from Requests where RequestId = @id";
        var res = await _context.Connection().ExecuteAsync(sql, new { id });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK,"Delete Successfully");
    }

    public async Task<Response<List<Request>>> RequestByStatus(Status status)
    {
        var sql = @"select * from Requests where Status = @sta";
        var res = await _context.Connection().QueryAsync<Request>(sql, new { sta = status.ToString() });
        return new Response<List<Request>>(res.ToList());
    }

    public async Task<Response<List<Request>>> RequestHistory(int fromUserId)
    {
        var sql = @"select * from Requests where RequestId = @Id";
        var res = await _context.Connection().QueryAsync<Request>(sql, new { Id = fromUserId });
        return new Response<List<Request>>(res.ToList());
    }

    public async Task<Response<bool>> ChengStatus(Status status, int fromUserId)
    {
        var sql = @"update Requests set Status = @sta where RequestId = @Id";
        var res = await _context.Connection().ExecuteAsync(sql,new { sta = status.ToString(), Id = fromUserId });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError,"Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK,"Status update Successfully");
    }
}