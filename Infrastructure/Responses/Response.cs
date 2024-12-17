using System.Net;

namespace Infrastructure.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T Data { get; set; }
    public string? Massage { get; set; }


    public Response(T? data)
    {
        StatusCode = 200;
        Data = data;
        Massage = "Success";
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Massage = message;
    }
}