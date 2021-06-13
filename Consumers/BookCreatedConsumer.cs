using System;
using System.Threading.Tasks;
using BooksApi.Consumers.Model;
using BooksApi.Helpers;
using BooksApi.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace BooksApi.Consumers
{
    public class BookCreatedConsumer : IConsumer<BookCreatedMessage>
    {
        ILogger<BookCreatedConsumer> _logger;
        public BookCreatedConsumer(ILogger<BookCreatedConsumer> logger)
        {
            this._logger = logger;
        }

        public async Task Consume(ConsumeContext<BookCreatedMessage> context)
        {
            // mail at
            _logger.LogInformation("Value: {Value}", context.Message.Author);
            try
            {
                context.Message.SendBookCreatedMessage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}