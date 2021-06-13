using System.Collections.Generic;
using BooksApi.Models;
using BooksApi.Services.Interfaces;

namespace BooksApi.Services.Interfaces
{
    public interface IBookService : IService<Book>
    {
    }
}