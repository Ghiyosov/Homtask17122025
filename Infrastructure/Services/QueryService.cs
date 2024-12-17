using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class QueryService(IContext _context)
{
    public async Task<Response<List<User>>> GetUsersHaveSkill()
    {
        var sql = @"select *
            from users as u 
            join skills as s on u.userId=s.userId";
        var res = await _context.Connection().QueryAsync<User>(sql);
        return new Response<List<User>>(res.ToList());
    }

    public async Task<Response<List<User>>> GetUsersRequestTime(int count, string date)// cout-mikdpor, date-(day , month, year) interval megirem useroi da hami interval request dora mekova  
    {
        var sql = $@"SELECT DISTINCT u.UserId, u.FullName, u.Email, u.Phone, u.City, u.CreatedAt
                    FROM Users u
                    JOIN Requests r ON u.UserId = r.FromUserId
                    WHERE r.Status = 'Pending' AND r.CreatedAt >= NOW() - INTERVAL '{count} {date}';";
        var res = await _context.Connection().QueryAsync<User>(sql);
        return new Response<List<User>>(res.ToList());
    }

    public async Task<Response<List<string>>> GetPopularSkills()
    {
        var sql = $@"select 'Skill : '||s.title||' Cont users : '||count(u.UserId)
                    from Skills as s
                    join Users as u on s.UserId=u.UserId
                    group by s.title
                    order by count(u.UserId) DESC";
        var res = await _context.Connection().QueryAsync<string>(sql);
        return new Response<List<string>>(res.ToList());
    }
    
    
}