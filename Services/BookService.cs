using BooksApi.Models;
using BooksApi.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using BooksApi.Services.Interfaces;

namespace BooksApi.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IBookstoreDatabaseSettings settings) : base(settings)
        {
        }
    }
}