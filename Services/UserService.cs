using BooksApi.Interfaces;
using BooksApi.Models;
using BooksApi.Services.Interfaces;
using MongoDB.Driver;

namespace BooksApi.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IBookstoreDatabaseSettings settings) : base(settings)
        {
        }
    }
}