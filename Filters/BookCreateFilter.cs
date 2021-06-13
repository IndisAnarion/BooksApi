using System.Threading.Tasks;
using BooksApi.Consumers.Model;
using BooksApi.Models;
using BooksApi.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BooksApi.Filters
{
    public class BookCreateFilter : IAsyncResultFilter
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IUserService userService;

        public BookCreateFilter(IPublishEndpoint publishEndpoint, IUserService userService)
        {
            this.publishEndpoint = publishEndpoint;
            this.userService = userService;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // öncesi
            await next.Invoke().ConfigureAwait(false);
            if (context.Result is ObjectResult result)
            {
                var x = result.Value;
                var id = x.GetType().GetProperty("Id").GetValue(x);
                Book book = (Book)(object)result.Value;

                // user'ları al
                var users = await this.userService.GetAsync().ConfigureAwait(false);
                foreach (User user in users)
                {
                    await this.publishEndpoint.Publish(new BookCreatedMessage
                    {
                        Author = book.Author,
                        Name = book.BookName,
                        Price = book.Price,
                        ToAddress = user.Email
                    }).ConfigureAwait(false);
                }
                // sonrası
                // her kullanıcı için mail gönderim mesajı publish et
            }
        }
    }
}