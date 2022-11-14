using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelListing.API.Data;
using HotelListing.API.Core.Models;

namespace HotelListing.API.Core.Contarct
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<PageResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<bool> Exists(int id);

    }
}
