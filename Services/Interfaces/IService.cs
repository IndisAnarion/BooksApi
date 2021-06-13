using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Interfaces;

namespace BooksApi.Services.Interfaces
{
    public interface IService<T> where T: IEntity
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T document);
        Task UpdateAsync(string id, T document);
        Task RemoveAsync(T document);
        Task RemoveAsync(string id);
    }
}