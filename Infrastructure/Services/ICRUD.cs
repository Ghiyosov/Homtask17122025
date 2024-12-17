using Infrastructure.Responses;

namespace Infrastructure.Services;

public interface ICRUD<T>
{
    public Task<Response<List<T>>> GetAll();
    public Task<Response<T>> GetAllByID(int id);
    public Task<Response<bool>> Add(T entity);
    public Task<Response<bool>> Update(T entity);
    public Task<Response<bool>> Delete(int id);
}