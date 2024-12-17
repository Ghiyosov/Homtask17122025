using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController(ICRUD<User> userController):ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<Response<List<User>>> GetUsers()
    {
        return await userController.GetAll();
    }

    [HttpGet("GetById")]
    public async Task<Response<User>> GetUserById(int id)
    {
        return await userController.GetAllByID(id);
    }

    [HttpPost("Create")]
    public async Task<Response<bool>> PostUser(User user)
    {
        return await userController.Add(user);
    }

    [HttpPut("Update")]
    public async Task<Response<bool>> PutUser(User user)
    {
        return await userController.Update(user);
    }

    [HttpDelete("Delete")]
    public async Task<Response<bool>> DeleteUser(int id)
    {
        return await userController.Delete(id);
    }
}