using Domein.Entities;
using Domein.Enums;
using Infrastructure.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class RequestController(RequestService requestService) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<Response<List<Request>>> GetAll()
    {
        return await requestService.GetAll();
    }

    [HttpGet("GetById/{id}")]
    public async Task<Response<Request>> GetById(int id)
    {
        return await requestService.GetAllByID(id);
    }

    [HttpPost("Add")]
    public async Task<Response<bool>> Add(Request request)
    {
        return await requestService.Add(request);
    }

    [HttpPut("Update")]
    public async Task<Response<bool>> Update(Request request)
    {
        return await requestService.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<bool>> Delete(int id)
    {
        return await requestService.Delete(id);
    }

    [HttpGet("RequestByStatus")]
    public async Task<Response<List<Request>>> GetRequestsByStatus(Status status)
    {
        return await requestService.RequestByStatus(status);
    }

    [HttpGet("RequestHistory")]
    public async Task<Response<List<Request>>> GetRequestHistory(int requestId)
    {
        return await requestService.RequestHistory(requestId);
    }

    [HttpPut("ChengStatus")]
    public async Task<Response<bool>> ChengStatus(Status status, int requestId)
    {
        return await requestService.ChengStatus(status, requestId);
    }
}