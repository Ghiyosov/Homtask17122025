using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class SkillController(ICRUD<Skill> skillController) : ControllerBase
{
    [HttpGet("GetSkills")]
    public async Task<Response<List<Skill>>> GetSkills()
    {
        return await skillController.GetAll();
    }

    [HttpGet("GetSkills/{id}")]
    public async Task<Response<Skill>> GetSkill(int id)
    {
        return await skillController.GetAllByID(id);
    }

    [HttpPost("CreateSkill")]
    public async Task<Response<bool>> CreateSkill(Skill skill)
    {
        return await skillController.Add(skill);
    }

    [HttpPut("UpdateSkill")]
    public async Task<Response<bool>> UpdateSkill(Skill skill)
    {
        return await skillController.Update(skill);
    }

    [HttpDelete("DeleteSkill/{id}")]
    public async Task<Response<bool>> DeleteSkill(int id)
    {
        return await skillController.Delete(id);
    }
}