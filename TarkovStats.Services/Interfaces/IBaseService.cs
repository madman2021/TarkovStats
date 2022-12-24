namespace TarkovStats.Services.Services;

public interface IBaseService<T> where T : class
{
    Task<T?> GetById(int id);
}