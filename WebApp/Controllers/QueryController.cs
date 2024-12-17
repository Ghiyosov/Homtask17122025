using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class QueryController(QueryService service) : ControllerBase
{
    [HttpGet("GetUsersHaveSkill")]
    public async Task<Response<List<User>>> GetUsersHaveSkill()
    {
        return await service.GetUsersHaveSkill();
    }

    [HttpGet("GetUsersRequestTime")]
    public async Task<Response<List<User>>> GetUsersRequestTime(int count, string date)
    {
        return await service.GetUsersRequestTime(count, date);
    }

    [HttpGet("GetPopularSkills")]
    public async Task<Response<List<string>>> GetPopularSkills()
    {
        return await service.GetPopularSkills();
    }
}